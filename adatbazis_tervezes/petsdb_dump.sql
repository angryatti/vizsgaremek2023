-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Gép: db
-- Létrehozás ideje: 2023. Máj 15. 17:01
-- Kiszolgáló verziója: 8.0.30
-- PHP verzió: 8.0.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Adatbázis: `laravel`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `adverts`
--

CREATE TABLE `adverts` (
  `id` bigint UNSIGNED NOT NULL,
  `user_id` bigint UNSIGNED NOT NULL,
  `pet_id` bigint UNSIGNED NOT NULL,
  `state_id` bigint UNSIGNED NOT NULL,
  `contact_info` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `adverts`
--

INSERT INTO `adverts` (`id`, `user_id`, `pet_id`, `state_id`, `contact_info`) VALUES
(1, 1, 1, 13, 'Telefonon, hétvégén ne keressenek'),
(2, 2, 4, 13, 'Telefonon, hétvégén ne keressenek'),
(3, 4, 2, 18, 'Telefonon, hétvégén ne keressenek'),
(4, 5, 3, 13, 'Telefonon, hétvégén ne keressenek'),
(5, 3, 5, 1, 'Telefonon, hétvégén ne keressenek'),
(6, 3, 6, 1, 'Telefonon, hétvégén ne keressenek'),
(7, 3, 7, 1, 'Telefonon, hétvégén ne keressenek'),
(8, 3, 8, 1, 'Telefonon, hétvégén ne keressenek'),
(9, 3, 9, 1, 'Telefonon, hétvégén ne keressenek'),
(10, 3, 10, 1, 'Telefonon, hétvégén ne keressenek');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `catlist`
--

CREATE TABLE `catlist` (
  `id` bigint UNSIGNED NOT NULL,
  `catbreed` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `doglist`
--

CREATE TABLE `doglist` (
  `id` bigint UNSIGNED NOT NULL,
  `dogbreed` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `failed_jobs`
--

CREATE TABLE `failed_jobs` (
  `id` bigint UNSIGNED NOT NULL,
  `uuid` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `connection` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `queue` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `payload` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `exception` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `failed_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `migrations`
--

CREATE TABLE `migrations` (
  `id` int UNSIGNED NOT NULL,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(28, '2014_10_12_000000_create_users_table', 1),
(29, '2014_10_12_100000_create_password_resets_table', 1),
(30, '2019_08_19_000000_create_failed_jobs_table', 1),
(31, '2019_12_14_000001_create_personal_access_tokens_table', 1),
(32, '2023_03_30_162734_create_pet_table', 1),
(33, '2023_04_02_081631_create_doglist_table', 1),
(34, '2023_04_08_185414_create_states_table', 1),
(35, '2023_04_11_175119_create_catlist_table', 1),
(36, '2023_04_24_190646_create_adverts_table', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `password_resets`
--

CREATE TABLE `password_resets` (
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `personal_access_tokens`
--

CREATE TABLE `personal_access_tokens` (
  `id` bigint UNSIGNED NOT NULL,
  `tokenable_type` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tokenable_id` bigint UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `abilities` text COLLATE utf8mb4_unicode_ci,
  `last_used_at` timestamp NULL DEFAULT NULL,
  `expires_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `pets`
--

CREATE TABLE `pets` (
  `id` bigint UNSIGNED NOT NULL,
  `pet_name` varchar(35) COLLATE utf8mb4_unicode_ci NOT NULL,
  `born` int NOT NULL,
  `species` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `breed` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `gender` varchar(7) COLLATE utf8mb4_unicode_ci NOT NULL,
  `castrated` tinyint(1) NOT NULL,
  `img_userdefine` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `description` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `pets`
--

INSERT INTO `pets` (`id`, `pet_name`, `born`, `species`, `breed`, `gender`, `castrated`, `img_userdefine`, `description`) VALUES
(1, 'Morzsi', 2012, 'kutya', 'Németjuhász', 'Hím', 0, 'dog.jpg', 'A kiskutya két hete született, jövő héten elvihető.'),
(2, 'Csípi', 2003, 'kutya', 'Keverék', 'Hím', 0, 'dog.jpg', 'A kiskutya két hete született, jövő héten nagy eséllyel elvihető.'),
(3, 'Pannus', 2012, 'kutya', 'Szamojéd', 'Nőstény', 1, 'dog.jpg', 'A kislány kutya három hete született, ivartalanított, jövő héten elvihető.'),
(4, 'Bogyóka', 2012, 'kutya', 'Francia bulldog', 'Nőstény', 1, 'dog.jpg', 'A kislány kutya két hónapja született, ivartalanított, azonnal elvihető.'),
(5, 'Zeusz', 2014, 'kutya', 'Alaszkai malamut', 'Hím', 1, 'dog.jpg', 'A kiskutya három hete született, ivartalanított, jövő héten elvihető.'),
(6, 'Mirci', 2017, 'macska', 'Maine Coon', 'Nőstény', 1, 'cat.jpg', 'Háromhetes. A cica ivartalanított és féregtelenítve!'),
(7, 'Merkuri', 2018, 'macska', 'Amerikai drótszőrű', 'Hím', 0, 'cat.jpg', 'Kéthetes, jövő héten elvíhető, féregtelenítve!'),
(8, 'Picur', 2020, 'macska', 'Bengáli', 'Hím', 0, 'cat.jpg', 'Négyhetes, jövő héten elvíhető, féregtelenítve!'),
(9, 'Garfield', 2021, 'macska', 'Brit rövidszőrű', 'Hím', 0, 'cat.jpg', 'Háromhetes, jövő héten elvíhető, féregtelenítve!'),
(10, 'Stuart Little', 2020, 'egyeb', 'Egér', 'Hím', 0, 'others.jpg', 'Háromhetes, jövő héten elvíhető');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `states`
--

CREATE TABLE `states` (
  `id` bigint UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `states`
--

INSERT INTO `states` (`id`, `name`) VALUES
(1, 'Bács-Kiskun'),
(2, 'Baranya'),
(3, 'Békés'),
(4, 'Borsod-Abaúj-Zemplén'),
(5, 'Budapest'),
(6, 'Csongrád'),
(7, 'Fejér'),
(8, 'Győr-Moson-Sopron'),
(9, 'Hajdú-Bihar'),
(10, 'Heves'),
(11, 'Jász-Nagykun-Szolnok'),
(12, 'Komárom-Esztergom'),
(13, 'Nógrád'),
(14, 'Pest'),
(15, 'Somogy'),
(16, 'Szabolcs-Szatmár-Bereg'),
(17, 'Tolna'),
(18, 'Vas'),
(19, 'Veszprém'),
(20, 'Zala');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` bigint UNSIGNED NOT NULL,
  `user_name` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(35) COLLATE utf8mb4_unicode_ci NOT NULL,
  `full_name` varchar(35) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone_number` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `user_name`, `email`, `full_name`, `phone_number`, `password`, `remember_token`) VALUES
(1, 'proba1', 'proba1@proba.hu', 'Kiss Ádám', '+36709999999', '$2y$10$iq7U98MNJwzWDJa7AjBK4OKZxDKEXBxKWZgZ7EbfAYBpTVxiOSZKy', NULL),
(2, 'proba2', 'proba2@proba.hu', 'Benk Dénes', '+36709999999', '$2y$10$Jc/5PrrO3MFPuG1a4PEip.lTpNColVVtKdayY7dQzi6MQZ1omOY7W', NULL),
(3, 'proba3', 'proba3@proba.hu', 'Horváth Csaba', '+36709999999', '$2y$10$ckcTaF/aQQQelNmX2H6JBOoYj6V8H2256RROXyOkLkhnlIStvGT.u', NULL),
(4, 'proba4', 'proba4@proba.hu', 'Homok Attila', '+36709999999', '$2y$10$nHrFh0i5itNMpInJV0RivOp9pHp.GL1Gzak9zuaflf3noLcOxsjjG', NULL),
(5, 'proba5', 'proba5@proba.hu', 'Dávid Balázs', '+36709999999', '$2y$10$aeaqAw49wtM5gfXL11Zg6eNfmHaXq37p/7oNa1eGwtH3bfxD9gYy2', NULL);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `adverts`
--
ALTER TABLE `adverts`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `catlist`
--
ALTER TABLE `catlist`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `doglist`
--
ALTER TABLE `doglist`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `failed_jobs`
--
ALTER TABLE `failed_jobs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `failed_jobs_uuid_unique` (`uuid`);

--
-- A tábla indexei `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `password_resets`
--
ALTER TABLE `password_resets`
  ADD KEY `password_resets_email_index` (`email`);

--
-- A tábla indexei `personal_access_tokens`
--
ALTER TABLE `personal_access_tokens`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `personal_access_tokens_token_unique` (`token`),
  ADD KEY `personal_access_tokens_tokenable_type_tokenable_id_index` (`tokenable_type`,`tokenable_id`);

--
-- A tábla indexei `pets`
--
ALTER TABLE `pets`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `states`
--
ALTER TABLE `states`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `users_user_name_unique` (`user_name`),
  ADD UNIQUE KEY `users_email_unique` (`email`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `adverts`
--
ALTER TABLE `adverts`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `catlist`
--
ALTER TABLE `catlist`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `doglist`
--
ALTER TABLE `doglist`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `failed_jobs`
--
ALTER TABLE `failed_jobs`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT a táblához `personal_access_tokens`
--
ALTER TABLE `personal_access_tokens`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `pets`
--
ALTER TABLE `pets`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `states`
--
ALTER TABLE `states`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;