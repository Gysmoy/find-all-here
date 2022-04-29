using System;
using System.Collections.Generic;
using System.Text;

namespace find_all_here.Models
{
    public static class StoredProcedures
    {
        public static string GetAllProducts = @"
        SELECT
            P.id, P.name, P.description, P.purchase_price, P.sale_price,
            P.proportions, P.stock, P.tags, P.product_status, P.update_date, P.status,
            B.id AS b_id, B.brand AS b_name, B.status AS b_status,
            C.id AS c_id, C.category AS c_name, C.status AS c_status,
            U.id AS u_id, U.names AS u_names, U.surnames AS u_surnames,
            U.username AS u_username, U.email AS u_email,
            U.gender AS u_gender, U.address AS u_address, U.phone AS u_phone
        FROM PRODUCTS P INNER
        JOIN BRANDS B ON P._brand = B.id
        JOIN CATEGORIES C ON P._category = C.id
        JOIN USERS U ON P._user = U.id
        ORDER BY P.update_date DESC
        ";

        public static string GetUserById = @"
        SELECT 
            U.id, U.names, U.surnames, U.username, U.email,
            U.gender, U.birth_date, U.address, U.phone
        FROM USERS U
        WHERE id = ?
        ";

        public static string GetUserByUsernameAndPassword = @"
        SELECT 
            U.id, U.names, U.surnames, U.username, U.email,
            U.password, U.gender, U.birth_date, U.address, U.phone
        FROM USERS U
        WHERE
            (email = ? OR username = ?) AND password = ?
        ";
        public static string ExistUser = @"
        SELECT U.id FROM USERS U
        WHERE email = ? OR username = ?
        ";

        public static string SetUser = @"
        INSERT INTO USERS (
            names, surnames, username, email, password,
            birth_date, phone
        ) VALUES (?, ?, ?, ?, ?, ?, ?)
        ";
        public static string UpdateUser = @"
        UPDATE USERS SET 
            names=?, 
            surnames=?, 
            username=?, 
            email=?, 
            gender=?, 
            birth_date=?, 
            address=?, 
            phone=? 
        WHERE id = ?
        ";
    }
}
