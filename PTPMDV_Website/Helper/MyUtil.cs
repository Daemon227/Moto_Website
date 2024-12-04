using System.Text;

namespace PTPMDV_Website.Helper
{
    public class MyUtil
    {
        public static string GenerateRandomKey(int length = 5)
        {
            var pattern = @"qwertyuiopasdfghjklzxcvbnm123456789POIUYTREQASDFGHJKLMNBVCXZ!@#$";
            var sb = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(pattern[rd.Next(0,pattern.Length)]);
            }
            return sb.ToString();
        }

        public static string UploadImg(IFormFile img, string folder)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", folder, img.FileName);
                using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
                {
                    img.CopyTo(myfile);
                }
                return img.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
