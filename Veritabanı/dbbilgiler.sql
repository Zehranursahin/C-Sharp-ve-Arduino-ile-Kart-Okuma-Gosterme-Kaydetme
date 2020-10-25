-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost
-- Üretim Zamanı: 25 Eki 2020, 19:47:39
-- Sunucu sürümü: 8.0.17
-- PHP Sürümü: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `dbbilgiler`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kisibilgileri`
--

CREATE TABLE `kisibilgileri` (
  `kisiId` int(11) NOT NULL,
  `ad` varchar(15) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL,
  `soyad` varchar(15) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL,
  `foto` text CHARACTER SET utf8 COLLATE utf8_turkish_ci,
  `telNo` varchar(11) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL,
  `kartNo` varchar(15) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kisibilgileri`
--

INSERT INTO `kisibilgileri` (`kisiId`, `ad`, `soyad`, `foto`, `telNo`, `kartNo`) VALUES
(1, 'Bahadır', 'Düzcan', 'https://i.hizliresim.com/gyATdu.jpg', '05356011120', '0C 1A DF 21'),
(2, 'Zehra Nur', 'Şahin', 'https://i.hizliresim.com/ZU2XpT.jpg', '05415383015', 'D3 85 40 43');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `log`
--

CREATE TABLE `log` (
  `logId` int(11) NOT NULL,
  `logText` text COLLATE utf8_turkish_ci NOT NULL,
  `zaman` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `log`
--

INSERT INTO `log` (`logId`, `logText`, `zaman`) VALUES
(1, 'Bahadır Başarıyla Giriş Yaptı\n25/10/2020 22:41', '2020-10-25 19:41:55'),
(2, 'Zehra Nur Başarıyla Giriş Yaptı\n25/10/2020 22:43', '2020-10-25 19:43:10'),
(3, 'Bahadır Başarıyla Giriş Yaptı\n25/10/2020 22:44', '2020-10-25 19:44:40'),
(4, 'Zehra Nur Başarıyla Giriş Yaptı\n25/10/2020 22:45', '2020-10-25 19:45:28');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `kisibilgileri`
--
ALTER TABLE `kisibilgileri`
  ADD PRIMARY KEY (`kisiId`);

--
-- Tablo için indeksler `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`logId`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `kisibilgileri`
--
ALTER TABLE `kisibilgileri`
  MODIFY `kisiId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `log`
--
ALTER TABLE `log`
  MODIFY `logId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
