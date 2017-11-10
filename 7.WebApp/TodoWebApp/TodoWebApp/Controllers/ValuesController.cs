using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebApp.Controllers
{
    //http://coder.com.tr/api/values
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //HTTP METHODS
        /* GET : sunucu tarafından genellikle bir veri almak için kullandığımız metod
         * POST : ben istemci tarafından sunucuya bir veri gönderirken kullanıyodum.. hani formların action larına get,post gibi değerler yazıyoruz ya bundan dolayı
         * PUT : bir veri eklemek istediğimiz zaman kullanıyorum
         * PATCH : bir veri üzerinde belirli bir kısımda değişiklik yapmak istediğim zaman kullanıyorum.. */
         // genel olarak bakıldığında ben biriyle yaptığım işi bir diğeriyle de yapabliyorum mesela ben POST la da bir veri ekleyebilirim, PUT la da bir veri ekleyebilirim.. bundan dolayı ağırlıklı olarak GET VE POST kullanılır PUT ÇOK kullanılmaz..enterprise projelerde put u kullanırlar genelde

        //http://coder.com.tr/api/values
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()  // koleksiyon tipinde bir string dizi dönücek
        {
            return new string[] { "value1", "value2" }; // otomatik olarak bu veri gönderilirken json formatına döndürülüyor
        }

        //http://coder.com.tr/api/values/5
        // GET api/values/5
        [HttpGet("{id}")] //httpget ve httppost attributeleri: httpget altında yazan metodun post isteklerine mi get isteklerine mi cevap vereceğimi belirlememe yarıyodu.. get dediğim zaman get isteklerine cevap veriyor sadece http üzerinden gelen 
        public string Get(int id)
        {
            return "value";
        }

        //http://coder.com.tr/api/values
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        //http://coder.com.tr/api/values/5
        // PUT api/values/5
        [HttpPut("{id}")] //insert işlemi için gerçekleştirliyo
        public void Put(int id, [FromBody]string value)
        {
        }

        //http://coder.com.tr/api/values/5
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
//genel olarak http nin temel istekleri üzerinde ayrıştırma yapılıyor routıng de