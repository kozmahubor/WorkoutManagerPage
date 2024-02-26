using IUE7VU_ASP_2022231.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace IUE7VU_ASP_2022231.Logic
{
    public class ImageLogic
    {
        private readonly IHostingEnvironment hostEnvironment;
        public ImageLogic(IHostingEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public FileInfo GetFileInfoOfImage(string imageName)
        {
            string relativePath = Path.Combine(hostEnvironment.WebRootPath, "images", imageName);
            FileInfo fileInfo = new FileInfo(relativePath);
            return fileInfo;
        } 

        public (string, byte[], string) SetImageByMuscleType(Workout workout)
        {
            ImageLogic imageLogic = new ImageLogic(hostEnvironment);
            FileInfo fileInfo = imageLogic.GetFileInfoOfImage("default.png");
            switch (workout.WorkoutDifficulty)
            {
                case Models.Enums.WorkoutDifficulty.Easy:
                    fileInfo = imageLogic.GetFileInfoOfImage("easy.gif");
                    break;
                case Models.Enums.WorkoutDifficulty.Medium:
                    fileInfo = imageLogic.GetFileInfoOfImage("medium.gif");
                    break;
                case Models.Enums.WorkoutDifficulty.Hard:
                    fileInfo = imageLogic.GetFileInfoOfImage("hard.gif");
                    break;
                case Models.Enums.WorkoutDifficulty.Extreme:
                    fileInfo = imageLogic.GetFileInfoOfImage("extreme.gif");
                    break;
            }
            byte[] data = File.ReadAllBytes(fileInfo.FullName);
            //byte[] data = new byte[fileInfo.Length];
            string imagename = workout.PersonId + "." + fileInfo.FullName.Split(".")[1];
            System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", imagename), data);
            workout.ImageFileName = imagename;
            workout.Data = data;
            workout.ContentType = "image/gif";
            //string[] workoutOutData = new string[3] { imagename, data.ToString(), workout.ContentType};
            return (workout.ImageFileName, workout.Data, workout.ContentType);
        }
    }
}
