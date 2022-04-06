// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
    jQuery(".mascaracpf").mask("999.999.999-99");
    jQuery(".mascaracnpj").mask("99.999.999/9999-99");
    jQuery('.mascaratelefonefixo').mask("(99) 9999-9999");
    jQuery(".mascaracep").mask("99.999-999");

});