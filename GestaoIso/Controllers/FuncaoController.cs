#nullable disable
using GestaoIso.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestaoIso.Controllers
{
    [Authorize]
    public class FuncaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Funcao.Include(f => f.DominioEducacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Funcao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao
                .Include(f => f.DominioEducacao)
                .FirstOrDefaultAsync(m => m.FuncaoId == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // GET: Funcao/Create
        public IActionResult Create()
        {
            ViewData["DominioIdEducacao"] = new SelectList(_context.Dominio, "DominioId", "Descricao");
            return View();
        }

        // POST: Funcao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncaoId,Cargo,Experiencia,DominioIdEducacao,Treinamento,CriacaoResp,CriacaoData,RevisaoResp,RevisaoData,AprovacaoStatus,AprovacaoResp,AprovacaoData,Status,ProdutoComentario")] Funcao funcao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcao);
                funcao.CriacaoResp = User.Identity.Name;
                funcao.CriacaoData = DateTime.Now;
                funcao.Status = "Aguardando Aprovação";
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    if (ex.InnerException != null &&
                       ex.InnerException.Message.Contains("duplicada"))
                    {
                        ModelState.AddModelError(string.Empty, "Função já cadastrada!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    ViewData["DominioIdEducacao"] = new SelectList(_context.Dominio, "DominioId", "Descricao", funcao.DominioIdEducacao);
                    return View(funcao);
                }
            }
            ViewData["DominioIdEducacao"] = new SelectList(_context.Dominio, "DominioId", "Descricao", funcao.DominioIdEducacao);
            return View(funcao);
        }

        // GET: Funcao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao.FindAsync(id);
            if (funcao == null)
            {
                return NotFound();
            }
            ViewData["DominioIdEducacao"] = new SelectList(_context.Dominio, "DominioId", "Descricao", funcao.DominioIdEducacao);
            return View(funcao);
        }

        // POST: Funcao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncaoId,Cargo,Experiencia,DominioIdEducacao,Treinamento,CriacaoResp,CriacaoData,RevisaoResp,RevisaoData,AprovacaoStatus,AprovacaoResp,AprovacaoData,Status,ProdutoComentario")] Funcao funcao)
        {
            if (id != funcao.FuncaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                funcao.RevisaoData = DateTime.Now;
                funcao.RevisaoResp = User.Identity.Name;
                if (funcao.AprovacaoStatus == true)
                {
                    funcao.Status = "Aprovado";
                }
                else
                {
                    funcao.Status = "Aguardando Aprovação";
                }
                try
                {
                    _context.Update(funcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncaoExists(funcao.FuncaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (System.Exception ex)
                {
                    if (ex.InnerException != null &&
                       ex.InnerException.Message.Contains("duplicada"))
                    {
                        ModelState.AddModelError(string.Empty, "Função já cadastrada!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    ViewData["DominioIdEducacao"] = new SelectList(_context.Dominio, "DominioId", "Descricao", funcao.DominioIdEducacao);
                    return View(funcao);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["DominioIdEducacao"] = new SelectList(_context.Dominio, "DominioId", "Descricao", funcao.DominioIdEducacao);
            return View(funcao);
        }

        // GET: Funcao/Approve/5
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao.FindAsync(id);
            if (funcao == null)
            {
                return NotFound();
            }
            ViewData["DominioIdEducacao"] = new SelectList(_context.Dominio, "DominioId", "Descricao", funcao.DominioIdEducacao);
            return View(funcao);
        }

        // POST: Funcao/Approve/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, [Bind("FuncaoId,Cargo,Experiencia,DominioIdEducacao,Treinamento,CriacaoResp,CriacaoData,RevisaoResp,RevisaoData,AprovacaoStatus,AprovacaoResp,AprovacaoData,Status,ProdutoComentario")] Funcao funcao)
        {
            if (id != funcao.FuncaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (funcao.AprovacaoStatus == true)
                {
                    funcao.AprovacaoData = DateTime.Now;
                    funcao.AprovacaoResp = User.Identity.Name;
                    funcao.Status = "Aprovado";
                }
                try
                {
                    _context.Update(funcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncaoExists(funcao.FuncaoId))
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
            ViewData["DominioIdEducacao"] = new SelectList(_context.Dominio, "DominioId", "Descricao", funcao.DominioIdEducacao);
            return View(funcao);
        }


        // GET: Funcao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao
                .Include(f => f.DominioEducacao)
                .FirstOrDefaultAsync(m => m.FuncaoId == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // POST: Funcao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcao = await _context.Funcao.FindAsync(id);
            _context.Funcao.Remove(funcao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncaoExists(int id)
        {
            return _context.Funcao.Any(e => e.FuncaoId == id);
        }
    }
}
