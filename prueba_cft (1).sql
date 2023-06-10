-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 10-06-2023 a las 02:26:51
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `prueba_cft`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asignaturas`
--

CREATE TABLE `asignaturas` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `Codigo` varchar(30) NOT NULL,
  `FechaActualizacion` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `asignaturas`
--

INSERT INTO `asignaturas` (`Id`, `Nombre`, `Descripcion`, `Codigo`, `FechaActualizacion`) VALUES
(3, 'Matematicas', 'Modulo de Matematicas', 'MATE098', '2003-09-16'),
(4, 'Tecnologias Web', 'Modulo Tecnologias Web', 'TEC873', '1997-09-16');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asignaturasestudiantes`
--

CREATE TABLE `asignaturasestudiantes` (
  `EstudianteId` int(11) NOT NULL,
  `AsignaturaId` int(11) NOT NULL,
  `Id` int(11) NOT NULL,
  `FechaRegistro` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `asignaturasestudiantes`
--

INSERT INTO `asignaturasestudiantes` (`EstudianteId`, `AsignaturaId`, `Id`, `FechaRegistro`) VALUES
(4, 4, 2, '2001-12-14');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estudiantes`
--

CREATE TABLE `estudiantes` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Direccion` varchar(100) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Rut` varchar(45) NOT NULL,
  `Edad` int(11) DEFAULT NULL,
  `FechaNacimiento` date DEFAULT NULL,
  `Password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `estudiantes`
--

INSERT INTO `estudiantes` (`Id`, `Nombre`, `Apellido`, `Direccion`, `Email`, `Rut`, `Edad`, `FechaNacimiento`, `Password`) VALUES
(4, 'Paolo', 'Rojas', 'Linderos', 'felipe@gmail.com', '19.742.672-2', 21, '1990-03-14', 'kfaaai'),
(5, 'Jason', 'Edits', 'Las acacias', 'jason@gmail.com', '20.653.632-1', 24, '1994-10-18', 'kfaaai084'),
(6, 'Felipe ', 'Rojas', 'Saucache', 'felipe@gmail.com', '19.646.349-2', 25, '1999-03-14', 'kpasaaa948');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `notas`
--

CREATE TABLE `notas` (
  `Id` int(11) NOT NULL,
  `Calificacion` float NOT NULL,
  `Ponderacion` float NOT NULL,
  `EstudianteId` int(11) NOT NULL,
  `AsignaturaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `notas`
--

INSERT INTO `notas` (`Id`, `Calificacion`, `Ponderacion`, `EstudianteId`, `AsignaturaId`) VALUES
(3, 43, 40, 4, 4),
(4, 61, 60, 4, 4);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `asignaturas`
--
ALTER TABLE `asignaturas`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `asignaturasestudiantes`
--
ALTER TABLE `asignaturasestudiantes`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk_Estudiantes_has_Asignaturas_Asignaturas1_idx` (`AsignaturaId`),
  ADD KEY `fk_Estudiantes_has_Asignaturas_Estudiantes_idx` (`EstudianteId`);

--
-- Indices de la tabla `estudiantes`
--
ALTER TABLE `estudiantes`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `notas`
--
ALTER TABLE `notas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk_Notas_Estudiantes1_idx` (`EstudianteId`),
  ADD KEY `fk_Notas_Asignaturas1_idx` (`AsignaturaId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `asignaturas`
--
ALTER TABLE `asignaturas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `asignaturasestudiantes`
--
ALTER TABLE `asignaturasestudiantes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `estudiantes`
--
ALTER TABLE `estudiantes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `notas`
--
ALTER TABLE `notas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `asignaturasestudiantes`
--
ALTER TABLE `asignaturasestudiantes`
  ADD CONSTRAINT `fk_Estudiantes_has_Asignaturas_Asignaturas1` FOREIGN KEY (`AsignaturaId`) REFERENCES `asignaturas` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Estudiantes_has_Asignaturas_Estudiantes` FOREIGN KEY (`EstudianteId`) REFERENCES `estudiantes` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `notas`
--
ALTER TABLE `notas`
  ADD CONSTRAINT `fk_Notas_Asignaturas1` FOREIGN KEY (`AsignaturaId`) REFERENCES `asignaturas` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Notas_Estudiantes1` FOREIGN KEY (`EstudianteId`) REFERENCES `estudiantes` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
