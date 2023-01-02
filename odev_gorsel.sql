-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 02 Oca 2023, 13:28:47
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `odev_gorsel`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ayar`
--

CREATE TABLE `ayar` (
  `id` int(11) NOT NULL,
  `stokdurum` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cikis`
--

CREATE TABLE `cikis` (
  `id` int(11) NOT NULL,
  `kod` varchar(25) NOT NULL,
  `ad` varchar(25) NOT NULL,
  `adet` int(11) NOT NULL,
  `tarih` varchar(25) NOT NULL,
  `neden` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `cikis`
--

INSERT INTO `cikis` (`id`, `kod`, `ad`, `adet`, `tarih`, `neden`) VALUES
(0, 'ilac', '', 2, '7 Temmuz 2018 Cumartesi', 'fd'),
(0, 'Camasir Makinasi', '', 4, '19 Aralik 2022 Pazartesi', '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `depo`
--

CREATE TABLE `depo` (
  `id` int(11) NOT NULL,
  `tarih` varchar(25) NOT NULL,
  `dadi` varchar(25) NOT NULL,
  `sahip` varchar(25) NOT NULL,
  `yetkili` varchar(25) NOT NULL,
  `adres` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `depo`
--

INSERT INTO `depo` (`id`, `tarih`, `dadi`, `sahip`, `yetkili`, `adres`) VALUES
(1, '7 Temmuz 2018 Cumartesi', '12', '21', 'admin', '21');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `girisadet`
--

CREATE TABLE `girisadet` (
  `id` int(11) NOT NULL,
  `ukodu` varchar(25) NOT NULL,
  `tarih` varchar(25) NOT NULL,
  `adet` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `girisadet`
--

INSERT INTO `girisadet` (`id`, `ukodu`, `tarih`, `adet`) VALUES
(1, 'ilac', '7 Temmuz 2018 Cumartesi', 5),
(2, 'Makina Bobin', '19 Aralik 2022 Pazartesi', 5);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategori`
--

CREATE TABLE `kategori` (
  `id` int(11) NOT NULL,
  `kadi` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `kategori`
--

INSERT INTO `kategori` (`id`, `kadi`) VALUES
(3, 'Makina Parca');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici`
--

CREATE TABLE `kullanici` (
  `id` int(11) NOT NULL,
  `kullanici` varchar(25) NOT NULL,
  `sifre` varchar(25) NOT NULL,
  `yetki` varchar(25) NOT NULL,
  `tel` varchar(25) NOT NULL,
  `isim` varchar(25) NOT NULL,
  `soyisim` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `kullanici`
--

INSERT INTO `kullanici` (`id`, `kullanici`, `sifre`, `yetki`, `tel`, `isim`, `soyisim`) VALUES
(1, '1', '1', '0', '', '', '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `satis`
--

CREATE TABLE `satis` (
  `id` int(11) NOT NULL,
  `ad` varchar(25) NOT NULL,
  `sad` varchar(25) NOT NULL,
  `adet` int(11) NOT NULL,
  `fiyat` double NOT NULL,
  `tarih` varchar(25) NOT NULL,
  `aytarih` varchar(25) NOT NULL,
  `starih` varchar(25) NOT NULL,
  `kdv` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `satis`
--

INSERT INTO `satis` (`id`, `ad`, `sad`, `adet`, `fiyat`, `tarih`, `aytarih`, `starih`, `kdv`) VALUES
(2, 'Makina Bobin', 'Mobil Cezaevi', 1, 1691, '19.12.2022', '19-12-2022', '12-2022', 90),
(3, 'Ütü Kordonu', '', 1, 152, '19.12.2022', '19-12-2022', '12-2022', 90),
(4, 'Makina Bobin', 'Bursa/inegöl', 3, 5.7, '31.12.2022', '31-12-2022', '12-2022', 90),
(5, 'Makina Bobin', 'gwbze kocaeli', 3, 5.7, '1.01.2023', '1-1-2023', '1-2023', 90);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `stok`
--

CREATE TABLE `stok` (
  `id` int(11) NOT NULL,
  `adet` int(11) NOT NULL,
  `ukodu` varchar(25) NOT NULL,
  `gurup` varchar(25) NOT NULL,
  `kdv` double NOT NULL,
  `pbirim` varchar(25) NOT NULL,
  `sfiyat` double NOT NULL,
  `afiyat` double NOT NULL,
  `aciklama` varchar(500) NOT NULL,
  `goz` varchar(25) NOT NULL,
  `raf` varchar(25) NOT NULL,
  `yetkili` varchar(25) NOT NULL,
  `tarih` varchar(25) NOT NULL,
  `tur` varchar(25) NOT NULL,
  `fadi` varchar(25) NOT NULL,
  `dadi` varchar(25) NOT NULL,
  `ad` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `stok`
--

INSERT INTO `stok` (`id`, `adet`, `ukodu`, `gurup`, `kdv`, `pbirim`, `sfiyat`, `afiyat`, `aciklama`, `goz`, `raf`, `yetkili`, `tarih`, `tur`, `fadi`, `dadi`, `ad`) VALUES
(3, 1, 'Makina Bobin', 'Makina Parca', 90, 'TL', 1691, 30, 'Ayhan Polattan Hediyedir', '0', '0', '1', '19 Aralik 2022 Pazartesi', 'Ayhanus', 'Ayhan Polat', '12', '67458'),
(4, 0, 'Camasir Makinasi', 'Makina Parca', 90, 'TL', 4180, 1300, '', '', '', '1', '19 Aralik 2022 Pazartesi', '', '', '12', '45623'),
(5, 5, 'Ütü Kordonu', 'Makina Parca', 90, 'TL', 152, 30, '', '', '', '1', '19 Aralik 2022 Pazartesi', '', '', '12', '23446'),
(6, 78, 'Buzdolabi Kapi Kontrasi', 'Makina Parca', 90, 'TL', 570, 240, '', '', '', '1', '19 Aralik 2022 Pazartesi', '', '', '12', '34824'),
(7, 65, 'Bulasik mak. Alt sepet', 'Makina Parca', 89, 'TL', 1323, 600, '', '', '', '1', '19 Aralik 2022 Pazartesi', '', '', '12', '12356'),
(8, 5, 'Çamasir Makinesi Ön Duvar', 'Makina Parca', 46, 'TL', 627.8, 380, '', '', '', '1', '19 Aralik 2022 Pazartesi', '', '', '12', '12575'),
(9, 5, 'Çamasir Makinesi Motoru', 'Makina Parca', 36, 'TL', 2856, 2000, '', '', '', '1', '20 Aralik 2022 Sali', 'Bosch', 'Mulkan Cile', '12', '3567');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `ayar`
--
ALTER TABLE `ayar`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `depo`
--
ALTER TABLE `depo`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `girisadet`
--
ALTER TABLE `girisadet`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kullanici`
--
ALTER TABLE `kullanici`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `satis`
--
ALTER TABLE `satis`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `stok`
--
ALTER TABLE `stok`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `ayar`
--
ALTER TABLE `ayar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `depo`
--
ALTER TABLE `depo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `girisadet`
--
ALTER TABLE `girisadet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `kategori`
--
ALTER TABLE `kategori`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `kullanici`
--
ALTER TABLE `kullanici`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `satis`
--
ALTER TABLE `satis`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `stok`
--
ALTER TABLE `stok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
