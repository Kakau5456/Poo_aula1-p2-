using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[Controller]")]
public class AlunosController : ControllerBase
{
    private static readonly List<Aluno>ListadeAlunos=new List<Aluno>()
    {
      new Aluno{Id=1,Nome="fulano"},
      new Aluno{Id=2,Nome="Wanda"}  
    };
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(ListadeAlunos);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno alunoAtualizado)
    {//percorre a lista de alunos
        foreach(var aluno in ListadeAlunos)
        //se encontrar troca o nome do aluno
        {
            if (aluno.Id == id)
            {
                aluno.Nome=alunoAtualizado.Nome;

                return Ok(aluno);
            }
        }
        return NotFound();
    }
}