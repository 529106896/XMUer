using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XMUER.Models.Home
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        #region 注册登录所需字段

        [Column("user_name")]
        public String userName { get; set; }

        [Column("password")]
        public String password { get; set; }

        #endregion

        #region 后台所需字段

        [Column("state")]
        public int state { get; set; }

        [Column("type")]
        public int type { get; set; }

        #endregion

        #region 个人资料所需字段
        [Column("gender")]
        public int gender { get; set; }

        [Column("birthday")]
        public DateTime birthday { get; set; }

        [Column("hometown")]
        public String hometown { get; set; }

        [Column("email")]
        public String email { get; set; }

        [Column("mobile")]
        public String mobile { get; set; }

        [Column("university")]
        public String university { get; set; }

        [Column("high_school")]
        public String highSchool { get; set; }

        [Column("junior_high_school")]
        public String juniorHighSchool { get; set; }

        [Column("primary_school")]
        public String primarySchool { get; set; }

        [Column("hobby_music")]
        public String hobbyMusic { get; set; }

        [Column("hobby_book")]
        public String hobbyBook { get; set; }

        [Column("hobby_movie")]
        public String hobbyMovie { get; set; }

        [Column("hobby_game")]
        public String hobbyGame { get; set; }

        [Column("hobby_anime")]
        public String hobbyAnime { get; set; }

        [Column("hobby_sport")]
        public String hobbySport { get; set; }

        [Column("hobby_other")]
        public String hobbyOther { get; set; }

        [Column("home_page_description")]
        public String homePageDescription { get; set; }

        #endregion

        #region 新鲜事页面所需字段
        [Column("real_name")]
        public String realName { get; set; }

        [Column("student_no")]
        public string StudentNo { get; set; }

        [Column("college")]
        public string College { get; set; }

        [Column("department")]
        public string Department { get; set; }

        [Column("major")]
        public string Major { get; set; }

        [Column("avatar")]
        public string Avatar { get; set; }

        [Column("md5_password")]
        public string Md5Password { get; set; }

        #endregion
    }
}
