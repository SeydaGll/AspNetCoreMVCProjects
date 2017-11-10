using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebApp.Models;

//IactionResult farklı durumlar söz konusu olabilir
namespace TodoWebApp.Controllers
{
    //localhost:port/api/Todo
    [Route("api/[controller]")]  //Attribute Routing // bu controller a ulaşmak için nasıl bir route yolu istemelerini istiyosam onu bildircem
    public class TodoController:Controller  // bunun içerisinde benim sürekli veritabanımla sürekli iletişimim olucak.. bütün action larımdan iletişim kurcam..her seferinde her action içerisinde br context tanımlaması yapmaktansa bir kere yaparım.zaten startup tarafından servislerime eklemiş olduğum datacontextimi sınıf içerisine alıp bunu kullancam.. biz bu yönteme dependency injecton diyoruz ve asp.net core varsayılan olarak yapı içerisinde bunu gömülü veriyor.. daha önceki mvs 5 ve önceki sürümlerde böyle bir yapı yoktu.. biz  bunu yapabilmek için ektra farklı inject vs gibi yapılar kullanıyoduk..oldukça kullanışlı SOLID prensiplerine uygun ve olması gerekn bir yöntem çünkü ben controller üzeerinde herhangi bir değişiklik yapabilirim 
    {
        #region dependency_injection

        private readonly TodoContext _context;   // sonradan değiştirilebilecek bir değişken(readonly)
        public TodoController(TodoContext context)  //mvc yada asp.net benim bu controller ımdan ne zaman bir örnek oluşturur? ne zamanki controller a bir istek geldi o zaman controller dan bir örnek oluşturcak.. uygulama ilk defa çalıştığında oluşturmaz.. ilk defa çalıştırdığınızda henüz herhangi bir request gelmemiştir yada gelmemiş olabilir bunu örneklemez.. ne zamanki controllera bir istek geldi o zaman controller dan bir örnek oluşturcak..yani ne zaman /todo yazılırsa..locahost 5000 diye istek geldi gidip neden controllerdan örnek oluştursun ki hafızada.. ne zaman /api/todo diye istek geldi o zaman bundan bir örnek oluşturuluyo
        {                       // o yüzden o class ın bir örneği oluşturulurken constr çalışcak.. bir class ın örneği oluşturulurken constr e başvurulur
            _context = context;
            if (_context.TodoItems.Count()==0)   //
            {
                _context.TodoItems.Add(new TodoItem { Name = "test Item" });
                _context.SaveChanges();
            }
        }
        #endregion

        //localhost:port/api/todo  - yukarda Todo burda todo yazdık..farketmiyor.. url yapılarında case sensitive yapılarını aramaz asp.net 
        [HttpGet]  //hangi isteğe cevap vereceğini belirtmek istiyorum..varsayılan olarak üzerine herhangi bir attribute yazmasamda HttpGet isteklerine cevap veriyor
        public IEnumerable<TodoItem> GetAll()  //liste TodoItem ı göndermek için
        {
            return _context.TodoItems.ToList(); //siz tabi araya Reposity,UnitofWOrk gibi farklı katmanlar ekleyip direk context ten çekmek yerine ordanda çekebilirsiniz.
        }

        [HttpGet("{id}",Name ="GetTodo")]   //tek bir todoitem ı göndericek ikinci bir metod yazıyoruz..am diğerinden ayıran bir özelliği olmalı.. o id ye sahip olan item ı gönderebileyim..Name ile yeni bir isim vermek için deidk
        public IActionResult GetById(long id)  //neden IActionResult döndük?. 
        {
            var item = _context.TodoItems.FirstOrDefault(p => p.Id == id);   //bu id ye sahip olan todoitem ı bulmam lazım..var item diyip sorgulayabiliirm..firstofdefault 2 farklı sonuç döndürebilir. 1. bu ıd ye sahip todo yoksa null döncek firstofdefault un yapısı gereği.. varsa da direk ıtem ı dönücek .. tabi ben durumu kontrol altında tutmak isterim
            if (item==null)
            {
                return NotFound();
            }
            return new ObjectResult(item);   //ObjectResult benim item ımı json a dönüştürcek. geriye IActionResult dönmemin sebebide bu..eğer ben burada başarılı bir şekilde ObjectResult ımı dönebilirsem http response da http nin 200 okey mesajıyla beraber gidicek yani işlem başarılı mesajıyla gidicek.. ama eğer item bulunamazsa notfound 404 cevabıyla gitmiş olucak böylelikle karşı tarafta durumdan haberdar olucak
        }

        [HttpPost]    //bir todoitem ı create edilmek istenirse
        public IActionResult Create([FromBody]TodoItem item)   //eğer ben bu metodda kullanıcının bana gönderdiği todo nesnesi içeriğini veitabanıma ekliceksem bana parametre olarak bu verilerin gelmesi lazım ve ben http de bu verileri body den alırım .. yani http request in body sinden gelicektir bana..şöyle bildiriyoruz..frombody.. requestin body sindeki 
        {
            if (item==null)
            {
                return BadRequest();
            }
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);

        }


        [HttpPut("{id}")]
        public IActionResult Update(long id,[FromBody] TodoItem item)
        {
            if (item==null || item.Id!=id)
            {
                return BadRequest();
            }
            var todo = _context.TodoItems.FirstOrDefault(q => q.Id == id);
            if (todo==null)
            {
                return NotFound();
            }
            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();  // çünkü update işleminden sonra herhangi bir içerik dönmeme gerek yok
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.FirstOrDefault(q => q.Id == id);
            if (todo==null)
            {
                return NotFound();
            }
            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();  //204mesajını döner
        }
    }
}
