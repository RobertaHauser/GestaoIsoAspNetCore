#nullable disable
using GestaoIso.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestaoIso.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Funcionario.Include(f => f.Funcao).Include(f => f.Pessoa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Funcao)
                .Include(f => f.Pessoa)
                .FirstOrDefaultAsync(m => m.PessoaIdFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }



        public void CriarViewBag(Funcionario? funcionario = null)
        {
            ViewData["FuncaoId"] = new SelectList(_context.Funcao, "FuncaoId", "Cargo", funcionario?.FuncaoId);

            ViewData["PessoaIdFuncionario"] = new SelectList(
                _context.Pessoa.Select(c => new { c.PessoaId, Nome = c.CpfCnpj + " - " + c.NomeCompleto})
                , "PessoaId", "Nome", funcionario?.PessoaIdFuncionario);
        }


        // GET: Funcionario/Create
        public IActionResult Create()
        {
            CriarViewBag();
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaIdFuncionario,PessoaId,DataAdmissao,DataDemissao,FuncaoId")] Funcionario funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(funcionario);
                    funcionario.CriacaoResp = User.Identity.Name;
                    funcionario.CriacaoData = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                CriarViewBag();
                return View(funcionario);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException != null &&
                   ex.InnerException.InnerException != null &&
                   ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    ModelState.AddModelError(string.Empty, "Função já cadastrada!");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(funcionario);
            }
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            CriarViewBag(funcionario);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaIdFuncionario,PessoaId,DataAdmissao,DataDemissao,FuncaoId")] Funcionario funcionario)
        {
            if (id != funcionario.PessoaIdFuncionario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                funcionario.RevisaoData = DateTime.Now;
                funcionario.RevisaoResp = User.Identity.Name;
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.PessoaIdFuncionario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            CriarViewBag(funcionario);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Funcao)
                .Include(f => f.Pessoa)
                .FirstOrDefaultAsync(m => m.PessoaIdFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.PessoaIdFuncionario == id);
        }
    }
}
