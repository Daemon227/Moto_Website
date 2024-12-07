namespace PTPMDV_Website.ViewModels
{
    public class CompareDataVM
    {
        public ICollection<MotoVM> Motos { get; set; }
        public ICollection<MotoVM> MotoToCompare { get; set; }
        public ICollection<TypeVM> Types { get; set; }
    }
}
