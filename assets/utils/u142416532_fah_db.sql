SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Estructura de tabla para la tabla `BRANDS`
--

CREATE TABLE `BRANDS` (
  `id` int(8) NOT NULL,
  `brand` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `status` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `CATEGORIES`
--

CREATE TABLE `CATEGORIES` (
  `id` int(8) NOT NULL,
  `category` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `status` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `COMMENTS`
--

CREATE TABLE `COMMENTS` (
  `id` int(8) NOT NULL,
  `comment` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `_product` int(8) NOT NULL,
  `_comment` int(8) NOT NULL,
  `_user` int(8) NOT NULL,
  `time` date NOT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `FOLLOWS`
--

CREATE TABLE `FOLLOWS` (
  `id` int(8) NOT NULL,
  `_user_follow` int(8) NOT NULL,
  `_user` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `IMAGES`
--

CREATE TABLE `IMAGES` (
  `id` int(8) NOT NULL,
  `mini` blob NOT NULL,
  `full` longblob NOT NULL,
  `type` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL,
  `orden` int(1) NOT NULL,
  `_products` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `NOTIFICATIONS`
--

CREATE TABLE `NOTIFICATIONS` (
  `id` int(8) NOT NULL,
  `_type` int(8) NOT NULL,
  `time` date NOT NULL,
  `_user_notified` int(8) NOT NULL,
  `_user` int(8) NOT NULL,
  `_status` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `NOTIFICATIONS_TYPE`
--

CREATE TABLE `NOTIFICATIONS_TYPE` (
  `id` int(8) NOT NULL,
  `type` varchar(32) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `PRODUCTS`
--

CREATE TABLE `PRODUCTS` (
  `id` int(8) NOT NULL,
  `name` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(250) COLLATE utf8mb4_unicode_ci NOT NULL,
  `_brand` int(8) NOT NULL,
  `_category` int(8) NOT NULL,
  `purchase_price` decimal(7,2) NOT NULL,
  `sale_price` decimal(7,2) NOT NULL,
  `proportions` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `stock` int(4) NOT NULL,
  `tags` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `product_status` varchar(32) COLLATE utf8mb4_unicode_ci NOT NULL,
  `update_date` date NOT NULL,
  `status` bit(1) NOT NULL,
  `_user` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `RATINGS`
--

CREATE TABLE `RATINGS` (
  `id` int(8) NOT NULL,
  `rate` int(1) NOT NULL,
  `comment` varchar(250) COLLATE utf8mb4_unicode_ci NOT NULL,
  `_user_qualified` int(8) NOT NULL,
  `_user` int(8) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `RECORDS`
--

CREATE TABLE `RECORDS` (
  `id` int(8) NOT NULL,
  `_user` int(8) NOT NULL,
  `date` datetime NOT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `RECORDS_DETAIL`
--

CREATE TABLE `RECORDS_DETAIL` (
  `id` int(8) NOT NULL,
  `_product` int(8) NOT NULL,
  `quantity` int(4) NOT NULL,
  `product_price` decimal(7,2) NOT NULL,
  `purchase_price` decimal(7,2) NOT NULL,
  `_record` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `SN_USERS`
--

CREATE TABLE `SN_USERS` (
  `id` int(8) NOT NULL,
  `social_network` varchar(320) COLLATE utf8mb4_unicode_ci NOT NULL,
  `_user` int(8) NOT NULL,
  `_social_network` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `SOCIAL_NETWORKS`
--

CREATE TABLE `SOCIAL_NETWORKS` (
  `id` int(8) NOT NULL,
  `description` varchar(16) COLLATE utf8mb4_unicode_ci NOT NULL,
  `background` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `icon` varchar(16) COLLATE utf8mb4_unicode_ci NOT NULL,
  `href` varchar(32) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `STATUS`
--

CREATE TABLE `STATUS` (
  `id` int(8) NOT NULL,
  `status` varchar(32) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `USERS`
--

CREATE TABLE `USERS` (
  `id` int(8) NOT NULL,
  `names` varchar(150) COLLATE utf8mb4_unicode_ci NOT NULL,
  `surnames` varchar(150) COLLATE utf8mb4_unicode_ci NOT NULL,
  `username` varchar(16) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(320) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `gender` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `birth_date` date NOT NULL,
  `address` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL,
  `profile_mini` blob NOT NULL,
  `profile_full` blob NOT NULL,
  `profile_type` varchar(16) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `BRANDS`
--
ALTER TABLE `BRANDS`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `CATEGORIES`
--
ALTER TABLE `CATEGORIES`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `COMMENTS`
--
ALTER TABLE `COMMENTS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_comment_product_idx` (`_product`),
  ADD KEY `fk_comment_comment_idx` (`_comment`),
  ADD KEY `fk_comment_user_idx` (`_user`);

--
-- Indices de la tabla `FOLLOWS`
--
ALTER TABLE `FOLLOWS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_follows_userfollow_idx` (`_user_follow`),
  ADD KEY `fk_follows_user_idx` (`_user`);

--
-- Indices de la tabla `IMAGES`
--
ALTER TABLE `IMAGES`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_images_products_idx` (`_products`);

--
-- Indices de la tabla `NOTIFICATIONS`
--
ALTER TABLE `NOTIFICATIONS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_notifications_type_idx` (`_type`),
  ADD KEY `fk_notifications_user_notified_idx` (`_user_notified`),
  ADD KEY `fk_notification_user_idx` (`_user`),
  ADD KEY `fk_notification_status_idx` (`_status`);

--
-- Indices de la tabla `NOTIFICATIONS_TYPE`
--
ALTER TABLE `NOTIFICATIONS_TYPE`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `PRODUCTS`
--
ALTER TABLE `PRODUCTS`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `RATINGS`
--
ALTER TABLE `RATINGS`
  ADD KEY `_user_UNIQUE` (`_user`),
  ADD KEY `fk_ratings_users_qualified_idx` (`_user_qualified`);

--
-- Indices de la tabla `RECORDS`
--
ALTER TABLE `RECORDS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_user_idx` (`_user`);

--
-- Indices de la tabla `RECORDS_DETAIL`
--
ALTER TABLE `RECORDS_DETAIL`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_records_detail_record_idx` (`_record`),
  ADD KEY `fk_records_detail_product_idx` (`_product`);

--
-- Indices de la tabla `SN_USERS`
--
ALTER TABLE `SN_USERS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_sn_users_social_networks_idx` (`_social_network`),
  ADD KEY `fk_sn_users_user_idx` (`_user`);

--
-- Indices de la tabla `SOCIAL_NETWORKS`
--
ALTER TABLE `SOCIAL_NETWORKS`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `STATUS`
--
ALTER TABLE `STATUS`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `USERS`
--
ALTER TABLE `USERS`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `BRANDS`
--
ALTER TABLE `BRANDS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `CATEGORIES`
--
ALTER TABLE `CATEGORIES`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `COMMENTS`
--
ALTER TABLE `COMMENTS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `FOLLOWS`
--
ALTER TABLE `FOLLOWS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `IMAGES`
--
ALTER TABLE `IMAGES`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `NOTIFICATIONS`
--
ALTER TABLE `NOTIFICATIONS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `PRODUCTS`
--
ALTER TABLE `PRODUCTS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `RECORDS`
--
ALTER TABLE `RECORDS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `RECORDS_DETAIL`
--
ALTER TABLE `RECORDS_DETAIL`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `SN_USERS`
--
ALTER TABLE `SN_USERS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `SOCIAL_NETWORKS`
--
ALTER TABLE `SOCIAL_NETWORKS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `STATUS`
--
ALTER TABLE `STATUS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `USERS`
--
ALTER TABLE `USERS`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `COMMENTS`
--
ALTER TABLE `COMMENTS`
  ADD CONSTRAINT `fk_comment_comment` FOREIGN KEY (`_comment`) REFERENCES `COMMENTS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_comment_product` FOREIGN KEY (`_product`) REFERENCES `PRODUCTS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_comment_user` FOREIGN KEY (`_user`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Filtros para la tabla `FOLLOWS`
--
ALTER TABLE `FOLLOWS`
  ADD CONSTRAINT `fk_follows_user` FOREIGN KEY (`_user`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_follows_userfollow` FOREIGN KEY (`_user_follow`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Filtros para la tabla `IMAGES`
--
ALTER TABLE `IMAGES`
  ADD CONSTRAINT `fk_images_produts` FOREIGN KEY (`_products`) REFERENCES `PRODUCTS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Filtros para la tabla `NOTIFICATIONS`
--
ALTER TABLE `NOTIFICATIONS`
  ADD CONSTRAINT `fk_notification_notifications_type` FOREIGN KEY (`_status`) REFERENCES `NOTIFICATIONS_TYPE` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_notification_type` FOREIGN KEY (`_type`) REFERENCES `STATUS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_notification_user_notified` FOREIGN KEY (`_user_notified`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_notifications_user` FOREIGN KEY (`_user`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Filtros para la tabla `RATINGS`
--
ALTER TABLE `RATINGS`
  ADD CONSTRAINT `fk_ratings_users` FOREIGN KEY (`_user`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ratings_users_qualified` FOREIGN KEY (`_user_qualified`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Filtros para la tabla `RECORDS`
--
ALTER TABLE `RECORDS`
  ADD CONSTRAINT `fk_user` FOREIGN KEY (`_user`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Filtros para la tabla `RECORDS_DETAIL`
--
ALTER TABLE `RECORDS_DETAIL`
  ADD CONSTRAINT `fk_records_detail_product` FOREIGN KEY (`_product`) REFERENCES `PRODUCTS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_records_detail_record` FOREIGN KEY (`_record`) REFERENCES `RECORDS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Filtros para la tabla `SN_USERS`
--
ALTER TABLE `SN_USERS`
  ADD CONSTRAINT `fk_sn_users_social_networks` FOREIGN KEY (`_social_network`) REFERENCES `SOCIAL_NETWORKS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_sn_users_user` FOREIGN KEY (`_user`) REFERENCES `USERS` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
