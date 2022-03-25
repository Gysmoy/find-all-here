using System;
using System.Collections.Generic;
using System.Text;

namespace find_all_here.csharp
{
    public class Tables
    {

        public class Activity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
        }
        public class ClsResponse
        {
            public int Status { get; set; }
            public string Message { get; set; }
        }
        public class ClsBrands : ClsResponse
        {
            public ClsBrand[] Data { get; set; }
        }
        public class ClsBrand
        {
            public int Id { get; set; }
            public string Brand { get; set; }
            public bool Status { get; set; }
        }
        public class ClsCategories : ClsResponse
        {
            public ClsCategory[] Data { get; set; }
        }
        public class ClsCategory
        {
            public int Id { get; set; }
            public string Category { get; set; }
            public bool Status { get; set; }
        }
        public class ClsStatuses : ClsResponse
        {
            public ClsStatus[] Data { get; set; }
        }
        public class ClsStatus
        {
            public int Id { get; set; }
            public string Status { get; set; }
        }
        public class ClsNotifications_types : ClsResponse
        {
            public ClsNotifications_type[] Data { get; set; }
        }
        public class ClsNotifications_type
        {
            public int Id { get; set; }
            public string Type { get; set; }

        }
        public class ClsSocials_Networks : ClsResponse
        {
            public ClsSocial_networks[] Data { get; set; }
        }
        public class ClsSocial_networks
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Background { get; set; }
            public string Icon { get; set; }
            public string Href { get; set; }
        }
        public class ClsUsers : ClsResponse
        {
            public ClsUser[] Data { get; set; }
        }
        public class ClsUser
        {
            public int Id { get; set; }
            public string Names { get; set; }
            public string Surnames { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Gender { get; set; }
            public string Birth_date { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Profile_mini { get; set; }
            public string Profile_type { get; set; }

        }
        public class ClsFollows : ClsResponse
        {
            public ClsFollow[] Data { get; set; }
        }
        public class ClsFollow
        {
            public int Id { get; set; }
            public ClsUser User_follow { get; set; }
            public ClsUser User { get; set; }
        }
        public class ClsSns_users : ClsResponse
        {
            public ClsSn_users[] Data { get; set; }
        }
        public class ClsSn_users
        {
            public int Id { get; set; }
            public string Value { get; set; }
            public ClsUser User { get; set; }
            public ClsSocial_networks Social_network { get; set; }
        }
        public class ClsRatings : ClsResponse
        {
            public ClsRating Data { get; set; }
        }
        public class ClsRating
        {
            public int Id { get; set; }
            public string Comment { get; set; }
            public ClsUser User_qualified { get; set; }
            public ClsUser User { get; set; }
            public string Date { get; set; }
        }
        public class ClsNotifications : ClsResponse
        {
            public ClsNotification[] Data { get; set; }
        }
        public class ClsNotification
        {
            public int Id { get; set; }
            public ClsStatus Type { get; set; }
            public string Time { get; set; }
            public ClsUser User_notified { get; set; }
            public ClsUser User { get; set; }
            public ClsNotifications_type Status { get; set; }
        }
        public class ClsRecords : ClsResponse
        {
            public ClsRecord[] Data { get; set; }
        }
        public class ClsRecord
        {
            public int Id { get; set; }
            public ClsUser User { get; set; }
            public string Date { get; set; }
            public bool Status { get; set; }
        }
        public class ClsProducts : ClsResponse
        {
            public ClsProduct[] Data { get; set; }
        }
        public class ClsProduct
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public ClsBrand Brand { get; set; }
            public ClsCategory Category { get; set; }
            public float Purchase_price { get; set; }
            public float Sale_price { get; set; }
            public string Proportions { get; set; }
            public int Stock { get; set; }
            public string Tags { get; set; }
            public string Product_status { get; set; }
            public string Update_date { get; set; }
            public bool Status { get; set; }
            public ClsUser User { get; set; }
        }
        public class ClsComments : ClsResponse
        {
            public ClsComment[] Data { get; set; }
        }
        public class ClsComment
        {
            public int Id { get; set; }
            public string Comment { get; set; }
            public ClsProduct Product { get; set; }
            public ClsComment Comment_referenced { get; set; }
            public ClsUser User { get; set; }
            public string Time { get; set; }
            public bool Status { get; set; }
        }
        public class ClsRecords_details : ClsResponse
        {
            public ClsRecords_detail[] Data { get; set; }
        }

        public class ClsRecords_detail
        {
            public int Id { get; set; }
            public ClsProduct Product { get; set; }
            public int Quantity { get; set; }
            public float Product_price { get; set; }
            public float Purchage_price { get; set; }
            public ClsRecord Record { get; set; }

        }
        public class ClsImages : ClsResponse
        {
            public ClsImage[] Data { get; set; }
        }
        public class ClsImage
        {
            public int Id { get; set; }
            public string Mini { get; set; }
            public string Type { get; set; }
            public int Orden { get; set; }
            public ClsProduct Product { get; set; }


        }
    }
}