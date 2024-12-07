using PTPMDV_Website.Models;

namespace PTPMDV_Website.ViewModels
{
    public class LibraryVM
    {
        public string MaLibrary { get; set; } = null!;

        public virtual ICollection<LibraryImageVM> LibraryImageVM { get; set; } = new List<LibraryImageVM>();

        //public virtual ICollection<MotoBike> MotoBikes { get; set; } = new List<MotoBike>();
    }
}
