using myHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Globalization;

namespace myHomeWork.Service
{
    public class ForumList
    {
        public myHomeWork.Models.myDataBaseEntities db = new Models.myDataBaseEntities();

        public List<Forum> GetData() 
        {
            var FList = db.Database.SqlQuery<Forum>("select * from Forum").AsQueryable();
            return (FList.ToList());
        }

        public void DBCreate(string f_title)
        {
            Forum newdata = new Forum();

            newdata.TITLE = f_title;
            newdata.BUD_DTM = DateTime.Now;
            
            db.Forum.Add(newdata);
            db.SaveChanges();
        }

        public void DBDelete(string f_id) 
        {
            int ifid = int.Parse(f_id);
            db.Database.SqlQuery<Forum>("DELETE FROM Forum WHERE ID=@ID ", new SqlParameter("@ID", ifid)).AsQueryable();
            //db.SaveChanges();
        }

        public List<ARTICLE> GetAData(string F_ID)
        {
            var p = db.Database.SqlQuery<ARTICLE>("select * from ARTICLE WHERE FORUM_ID=@FORUM_ID", new SqlParameter("@FORUM_ID", F_ID)).AsQueryable();
            return p.ToList();
        }

        public List<ARTICLEREPLY> GetRData(string A_ID, string F_ID)
        {
            var R = db.Database.SqlQuery<ARTICLEREPLY>("select * from ARTICLE WHERE FORUM_ID=@FORUM_ID", new SqlParameter("@FORUM_ID", F_ID)).AsQueryable();
            return R.ToList();
        }

        public void ADBCreate(string a_title, string a_body, string a_author, string f_id)
        {
            
            ARTICLE newdata = new ARTICLE();
           

            newdata.TITLE = a_title;
            newdata.AUTHOR = a_author;
            newdata.BODY = a_body;
           
            newdata.FORUM_ID = int.Parse(f_id);
            newdata.BUD_DTM = DateTime.Now;
            newdata.UPD_DTM = DateTime.Now;
            
            db.ARTICLE.Add(newdata);
            db.SaveChanges();
        }

    }
}