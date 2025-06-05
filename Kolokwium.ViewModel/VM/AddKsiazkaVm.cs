using System.ComponentModel.DataAnnotations;
namespace Kolokwium.ViewModel.VM
{
    public class AddKsiazkaVm
    {
    
        public string Tytul { get; set; } 
        public string Wydawnictwo { get; set; }
        public int RokWydania { get; set; }
        public int AutorId { get; set; }
 
    }
}