using Microsoft.AspNetCore.Http;  //session nesnesini kullanacağımız için http yi ekledik çünkü session http içinde..
using Newtonsoft.Json;  // seralize işlemi iiçin bir object in json formatına dönüştürülmesiyle uğraşacağımız için

namespace Cdr.Northwind.MVCWebUI.ExtensionMethods
{
    public static class SessionExtensionMethods  //extension metod barındıran bir sınıf olacağı için static yazdık
    {
        public static void SetObject(this ISession session,string key,object value) // bu session metod nereye yapışacak..Sesiion a yani ISession arayüzüne yapışmasın söylüyrum
        {
            string objectString = JsonConvert.SerializeObject(value); // verdiğim değeri json formatına dönüştür
            session.SetString(key, objectString);  //artık içerisinde string olarak saklayabilirim
        }

        public static T GetObject<T>(this ISession session,string key) where T:class  // get metodu daha farklı.. içerdeki objecti geriye alırken hangi tipten alacağım olayına karar vermem lazım.. 
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            T value = JsonConvert.DeserializeObject<T>(objectString);
            return value;
        }


    }
}
