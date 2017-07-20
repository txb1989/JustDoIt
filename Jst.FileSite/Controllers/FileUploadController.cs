using Jst.FileSite.Models;
using Jst.Utils.UtilsHelper;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jst.FileSite.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public JsonResult UploadFile()
        {

            //如果进行了分片
            if (Request.Form.AllKeys.Any(m => m == "chunk"))
            {
                //取得chunk和chunks
                int chunk = Convert.ToInt32(Request.Form["chunk"]);
                int chunks = Convert.ToInt32(Request.Form["chunks"]);
                //根据GUID创建用该GUID命名的临时文件
                string path = Server.MapPath("~/1/" + Request["guid"]);
                FileStream addFile = new FileStream(path, FileMode.Append, FileAccess.Write);
                BinaryWriter AddWriter = new BinaryWriter(addFile);
                //获得上传的分片数据流
                HttpPostedFileBase file = Request.Files.Get(0);
                Stream stream = file.InputStream;
                BinaryReader TempReader = new BinaryReader(stream);
                //将上传的分片追加到临时文件末尾
                AddWriter.Write(TempReader.ReadBytes((int)stream.Length));
                //关闭BinaryReader文件阅读器
                TempReader.Close();
                stream.Close();
                AddWriter.Close();
                addFile.Close();
                TempReader.Dispose();
                stream.Dispose();
                AddWriter.Dispose();
                addFile.Dispose();
                //如果是最后一个分片，则重命名临时文件为上传的文件名
                if (chunk == (chunks - 1))
                {
                    FileInfo fileinfo = new FileInfo(path);
                    fileinfo.MoveTo(Server.MapPath("~/1/" + Request.Files[0].FileName));
                }
            }
            else//没有分片直接保存
            {
                Request.Files[0].SaveAs(Server.MapPath("~/1/" + Request.Files[0].FileName));

            }
            Response.Write("ok");
            UploadResult result = new UploadResult()
            {
                msg = "成功",
                success = true,
                path = "http://www.baidu.com"
            };

            return Json(result);
        }

        /// <summary>
        /// 分片上传
        /// </summary>
        /// <returns></returns>
        public JsonResult UploadFileTrunk(string directory = "")
        {
            string baseDirectory = ConfigHelper.GetConfigSetting("BaseFileDiretory");
            if (Request.Files.Count > 0)//有文件
            {
                var file = Request.Files[0];
                string filename = file.FileName;
                string ext = Path.GetExtension(file.FileName);
                if (Request.Form.AllKeys.Any(m => m == "chunk"))//有分片
                {
                    //取得chunk和chunks
                    int chunk = Convert.ToInt32(Request.Form["chunk"]);
                    int chunks = Convert.ToInt32(Request.Form["chunks"]);
                    string tempPath = Server.MapPath("~/ChunkTemp/" + Request["guid"]);//以Guid未文件夹暂时存储临时分片文件
                    string path = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(filename)+"~" + chunk.ToString()+Path.GetExtension(filename));
                    if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
                    //FileStream addFile = new FileStream(path, FileMode.Create, FileAccess.Write);
                    file.SaveAs(path);
                    if (CheckAllFileReady(chunks, tempPath, filename))//如果所有文件都已准备好，则开始合并文件
                    {
                        MergeFile(tempPath, Path.Combine(baseDirectory, directory),  Guid.NewGuid().ToString("N")+ext);
                    }
                }
            }

            UploadResult result = new UploadResult()
            {
                msg = "成功",
                success = true,
                path = "http://www.baidu.com"
            };

            return Json(result);
        }

        /// <summary>
        /// 检查文件是否上传完成
        /// </summary>
        /// <param name="chunkSize"></param>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        private bool CheckAllFileReady(int chunkSize, string directory, string filename)
        {
            for (int i = 0; i < chunkSize; i++)
            {
                string filepath = Path.Combine(directory, Path.GetFileNameWithoutExtension(filename)+"~" + i+Path.GetExtension(filename));
                if (!System.IO.File.Exists(filepath))//如果分片不存在
                {
                    return false;
                }
                //如果分配存在，查看是否被占用
                if (CheckFileIsFree(filepath)) { return false; }
            }
            return true;

        }

        /// <summary>
        /// 查看文件是否被占用
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private bool CheckFileIsFree(string filepath)
        {
            bool inUse = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(filepath, FileMode.Open, FileAccess.Read,
                FileShare.None);
                inUse = false;
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用  
        }

        /// <summary>
        /// 合并文件
        /// </summary>
        /// <param name="chunkSize"></param>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        private void MergeFile(string tempDirectory,string directory,string filename)
        {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
           string[] files = Directory.GetFiles(tempDirectory);
            string dest = Path.Combine(directory, filename);
            FileStream fileStream = new FileStream(dest, FileMode.Append);
            BinaryWriter writer = new BinaryWriter(fileStream);
            if (files!=null && files.Length > 0)
            {
                foreach(var item in files)
                {
                    
                    FileStream tempFileStream = new FileStream(item,FileMode.Open, FileAccess.ReadWrite);
                    BinaryReader reader = new BinaryReader(tempFileStream);
                    writer.Write(reader.ReadBytes((int)tempFileStream.Length));
                    reader.Close();
                    tempFileStream.Close();
                    reader.Dispose();
                    tempFileStream.Dispose();
                }

            }
            writer.Close();
            fileStream.Close();
            writer.Dispose();
            fileStream.Dispose();

        }

        public JsonResult UploadImage()
        {
            UploadResult result = new UploadResult()
            {
                msg = "成功",
                success = true,
                path = "http://www.baidu.com"
            };
            return Json(result);
        }
    }
}