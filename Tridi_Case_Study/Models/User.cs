using System.ComponentModel.DataAnnotations.Schema;

namespace Tridi_Case_Study.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string fullName { get; set; }


        [NotMapped]
        public string imgUrl {

            get {

                string adress=  "";
                switch (id%5)
                {
                    case 0: adress = "https://bootdey.com/img/Content/avatar/avatar1.png"; break;
                    case 1: adress = "https://bootdey.com/img/Content/avatar/avatar2.png"; break;
                    case 2: adress = "https://bootdey.com/img/Content/avatar/avatar3.png"; break;
                    case 3: adress = "https://bootdey.com/img/Content/avatar/avatar4.png"; break;
                    case 4: adress = "https://bootdey.com/img/Content/avatar/avatar5.png"; break;
                    case 5: adress = "https://bootdey.com/img/Content/avatar/avatar6.png"; break;
                    default : adress = "https://bootdey.com/img/Content/avatar/avatar1.png"; break;
                }

                return adress;
                  

            }
        
        }
        public string password { get; set; }


    }
}
