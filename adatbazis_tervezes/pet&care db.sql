CREATE TABLE `catlist` (
  `id` bigint PRIMARY KEY NOT NULL,
  `size` varchar(35) NOT NULL,
  `catbreed` varchar(255) NOT NULL
);

CREATE TABLE `doglist` (
  `id` bigint PRIMARY KEY NOT NULL,
  `size` varchar(35) NOT NULL,
  `dogbreed` varchar(255) NOT NULL
);

CREATE TABLE `adverts` (
  `id` bigint PRIMARY KEY NOT NULL,
  `user_id` bigint NOT NULL,
  `pet_id` bigint NOT NULL,
  `city_id` bigint NOT NULL,
  `created_at` timestamp
);

CREATE TABLE `pets` (
  `id` bigint PRIMARY KEY NOT NULL,
  `pet_name` varchar(35) NOT NULL,
  `born` date NOT NULL,
  `species` varchar(6) NOT NULL,
  `petbreed_id` int DEFAULT NULL,
  `gender` varchar(7) NOT NULL,
  `castrated` tinyint(1) NOT NULL,
  `img_userdefine` varchar(100) DEFAULT NULL,
  `description` text NOT NULL
);

CREATE TABLE `cities` (
  `id` bigint PRIMARY KEY NOT NULL,
  `state_id` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL
);

CREATE TABLE `states` (
  `id` bigint PRIMARY KEY NOT NULL,
  `state` varchar(255) NOT NULL
);

CREATE TABLE `users` (
  `id` bigint NOT NULL,
  `user_name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `phone_number` varchar(255) DEFAULT NULL,
  `full_name` varchar(255) DEFAULT NULL,
  `password` varchar(255) NOT NULL,
  `contact_info` varchar(200) NOT NULL,
  `remember_token` varchar(100) DEFAULT NULL
);

ALTER TABLE `adverts` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `pets` ADD FOREIGN KEY (`id`) REFERENCES `adverts` (`pet_id`);

ALTER TABLE `pets` ADD FOREIGN KEY (`petbreed_id`) REFERENCES `catlist` (`id`);

ALTER TABLE `pets` ADD FOREIGN KEY (`petbreed_id`) REFERENCES `doglist` (`id`);

ALTER TABLE `adverts` ADD FOREIGN KEY (`city_id`) REFERENCES `cities` (`id`);

ALTER TABLE `states` ADD FOREIGN KEY (`id`) REFERENCES `cities` (`state_id`);
