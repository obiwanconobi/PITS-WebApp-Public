using System;

namespace ITWebApp.Features.GetUsers
{
    public class GetUserInformationResponseDto
    {
        public Guid UserID { get; set; }
        public Guid CustomerID { get; set; }
        public string user_forename { get; set; }
        public string user_surname { get; set; }
        public DateTime user_since { get; set; }
        public string user_phoneno { get; set; }
        public string user_email { get; set; }
        public Guid last_user_device_id { get; set; }
        public int user_permission_level { get; set; }
        public string user_win_username { get; set; }
        public int user_active { get; set; }

    }
}
