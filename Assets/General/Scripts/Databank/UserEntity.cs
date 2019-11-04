using System;

namespace DataBank
{
    [Serializable]
	public class UserEntity {

        // primary data
		public string id;
		public string name;
        public string email;
        public string contact;
        public string game_score;
        public string voucher_id;
        public string register_datetime;
        public string is_submitted;
	}
}