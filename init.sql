CREATE TABLE `Anemnesis` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Anemnesis` PRIMARY KEY (`Id`)
);

CREATE TABLE `Diagnosis` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Diagnosis` PRIMARY KEY (`Id`)
);

CREATE TABLE `DoctorGrade` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `NumberOfGrades` int NOT NULL,
    `Doctor` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_DoctorGrade` PRIMARY KEY (`Id`)
);

CREATE TABLE `Equipment` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Type` int NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Amount` int NOT NULL,
    CONSTRAINT `PK_Equipment` PRIMARY KEY (`Id`)
);

CREATE TABLE `Feedback` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Patient` longtext CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    `IsPrivate` tinyint(1) NOT NULL,
    `Publish` tinyint(1) NOT NULL,
    `IsAnonymous` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Feedback` PRIMARY KEY (`Id`)
);

CREATE TABLE `PatientFile` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    CONSTRAINT `PK_PatientFile` PRIMARY KEY (`Id`)
);

CREATE TABLE `RoomType` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_RoomType` PRIMARY KEY (`Id`)
);

CREATE TABLE `SecretaryReportDTO` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    CONSTRAINT `PK_SecretaryReportDTO` PRIMARY KEY (`Id`)
);

CREATE TABLE `Speciality` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Speciality` PRIMARY KEY (`Id`)
);

CREATE TABLE `State` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Code` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_State` PRIMARY KEY (`Id`)
);

CREATE TABLE `Symptom` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Symptom` PRIMARY KEY (`Id`)
);

CREATE TABLE `gradeDTO` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Grade` double NOT NULL,
    `Question` longtext CHARACTER SET utf8mb4 NULL,
    `DoctorGradeId` bigint NULL,
    `DoctorGradeId1` bigint NULL,
    CONSTRAINT `PK_gradeDTO` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_gradeDTO_DoctorGrade_DoctorGradeId` FOREIGN KEY (`DoctorGradeId`) REFERENCES `DoctorGrade` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_gradeDTO_DoctorGrade_DoctorGradeId1` FOREIGN KEY (`DoctorGradeId1`) REFERENCES `DoctorGrade` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Allergy` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `PatientFileId` bigint NULL,
    CONSTRAINT `PK_Allergy` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Allergy_PatientFile_PatientFileId` FOREIGN KEY (`PatientFileId`) REFERENCES `PatientFile` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Room` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `RoomCode` longtext CHARACTER SET utf8mb4 NULL,
    `RoomTypeId` bigint NULL,
    `MaxNumberOfPatientsForHospitalization` int NOT NULL,
    `CurrentNumberOfPatients` int NOT NULL,
    CONSTRAINT `PK_Room` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Room_RoomType_RoomTypeId` FOREIGN KEY (`RoomTypeId`) REFERENCES `RoomType` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Town` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `PostalNumber` longtext CHARACTER SET utf8mb4 NULL,
    `StateId` bigint NULL,
    CONSTRAINT `PK_Town` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Town_State_StateId` FOREIGN KEY (`StateId`) REFERENCES `State` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Address` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Street` longtext CHARACTER SET utf8mb4 NULL,
    `Number` int NOT NULL,
    `FullAddress` longtext CHARACTER SET utf8mb4 NULL,
    `TownId` bigint NULL,
    CONSTRAINT `PK_Address` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Address_Town_TownId` FOREIGN KEY (`TownId`) REFERENCES `Town` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `User` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `FirstName` longtext CHARACTER SET utf8mb4 NULL,
    `LastName` longtext CHARACTER SET utf8mb4 NULL,
    `Jmbg` longtext CHARACTER SET utf8mb4 NULL,
    `Email` longtext CHARACTER SET utf8mb4 NULL,
    `Phone` longtext CHARACTER SET utf8mb4 NULL,
    `DateOfBirth` datetime(6) NOT NULL,
    `AddressId` bigint NULL,
    `Username` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    `Image` longtext CHARACTER SET utf8mb4 NULL,
    `UserType` int NOT NULL,
    `SpecialtyId` bigint NULL,
    `DoctorGradeId` bigint NULL,
    `patientFileId` bigint NULL,
    `MiddleName` longtext CHARACTER SET utf8mb4 NULL,
    `Validation` tinyint(1) NULL,
    `Gender` longtext CHARACTER SET utf8mb4 NULL,
    `Race` longtext CHARACTER SET utf8mb4 NULL,
    `BloodType` longtext CHARACTER SET utf8mb4 NULL,
    `VerificationToken` longtext CHARACTER SET utf8mb4 NULL,
    `DoctorId` bigint NULL,
    CONSTRAINT `PK_User` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_User_DoctorGrade_DoctorGradeId` FOREIGN KEY (`DoctorGradeId`) REFERENCES `DoctorGrade` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_User_Speciality_SpecialtyId` FOREIGN KEY (`SpecialtyId`) REFERENCES `Speciality` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_User_PatientFile_patientFileId` FOREIGN KEY (`patientFileId`) REFERENCES `PatientFile` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_User_Address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `Address` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Article` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DatePublished` datetime(6) NOT NULL,
    `DoctorId` bigint NULL,
    `Topic` longtext CHARACTER SET utf8mb4 NULL,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Article` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Article_User_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `PatientNotification` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `PatientId` bigint NULL,
    `Read` tinyint(1) NOT NULL,
    `Message` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_PatientNotification` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PatientNotification_User_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `DoctorReportDTO` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `prescriptionId` bigint NULL,
    `AnemnesisId` bigint NULL,
    `PatientId` bigint NULL,
    CONSTRAINT `PK_DoctorReportDTO` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_DoctorReportDTO_Anemnesis_AnemnesisId` FOREIGN KEY (`AnemnesisId`) REFERENCES `Anemnesis` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_DoctorReportDTO_User_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Examination` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `PatientId` bigint NULL,
    `DoctorId` bigint NULL,
    `PeriodId` bigint NULL,
    `DiagnosisId` bigint NULL,
    `PrescriptionId` bigint NULL,
    `AnemnesisId` bigint NULL,
    `TherapyId` bigint NULL,
    `RefferalId` bigint NULL,
    `Canceled` tinyint(1) NOT NULL,
    `CanceledDate` datetime(6) NOT NULL,
    `PatientFileId` bigint NULL,
    `RoomOccupationReportDTOId` bigint NULL,
    `RoomOccupationReportDTOId1` bigint NULL,
    `SecretaryReportDTOId` bigint NULL,
    CONSTRAINT `PK_Examination` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Examination_Anemnesis_AnemnesisId` FOREIGN KEY (`AnemnesisId`) REFERENCES `Anemnesis` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Examination_Diagnosis_DiagnosisId` FOREIGN KEY (`DiagnosisId`) REFERENCES `Diagnosis` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Examination_User_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Examination_PatientFile_PatientFileId` FOREIGN KEY (`PatientFileId`) REFERENCES `PatientFile` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Examination_User_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Examination_SecretaryReportDTO_SecretaryReportDTOId` FOREIGN KEY (`SecretaryReportDTOId`) REFERENCES `SecretaryReportDTO` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Period` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `StartDate` datetime(6) NOT NULL,
    `EndDate` datetime(6) NOT NULL,
    `BusinessDayId` bigint NULL,
    CONSTRAINT `PK_Period` PRIMARY KEY (`Id`)
);

CREATE TABLE `BusinessDay` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `ShiftId` bigint NULL,
    `doctorId` bigint NULL,
    `roomId` bigint NULL,
    CONSTRAINT `PK_BusinessDay` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_BusinessDay_Period_ShiftId` FOREIGN KEY (`ShiftId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_BusinessDay_User_doctorId` FOREIGN KEY (`doctorId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_BusinessDay_Room_roomId` FOREIGN KEY (`roomId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `BusinessDayDTO` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DoctorId` bigint NULL,
    `PeriodId` bigint NULL,
    CONSTRAINT `PK_BusinessDayDTO` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_BusinessDayDTO_User_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_BusinessDayDTO_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `ExaminationDTO` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DoctorId` bigint NULL,
    `PatientId` bigint NULL,
    `RoomId` bigint NULL,
    `PeriodId` bigint NULL,
    CONSTRAINT `PK_ExaminationDTO` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ExaminationDTO_User_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_ExaminationDTO_User_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_ExaminationDTO_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_ExaminationDTO_Room_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `NotifyDoctorBusinessDay` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `shiftId` bigint NULL,
    `roomId` bigint NULL,
    CONSTRAINT `PK_NotifyDoctorBusinessDay` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_NotifyDoctorBusinessDay_Room_roomId` FOREIGN KEY (`roomId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_NotifyDoctorBusinessDay_Period_shiftId` FOREIGN KEY (`shiftId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Prescription` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `PeriodId` bigint NULL,
    CONSTRAINT `PK_Prescription` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Prescription_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Referral` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `PeriodId` bigint NULL,
    `DoctorId` bigint NULL,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Referral` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Referral_User_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Referral_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `RoomOccupationReportDTO` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `roomId` bigint NULL,
    `periodId` bigint NULL,
    CONSTRAINT `PK_RoomOccupationReportDTO` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_RoomOccupationReportDTO_Period_periodId` FOREIGN KEY (`periodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_RoomOccupationReportDTO_Room_roomId` FOREIGN KEY (`roomId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Therapy` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Note` longtext CHARACTER SET utf8mb4 NULL,
    `PeriodId` bigint NULL,
    CONSTRAINT `PK_Therapy` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Therapy_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Hospitalization` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `PeriodId` bigint NULL,
    `RoomId` bigint NULL,
    `DoctorId` bigint NULL,
    `PatientId` bigint NULL,
    `PatientFileId` bigint NULL,
    `RoomOccupationReportDTOId` bigint NULL,
    CONSTRAINT `PK_Hospitalization` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Hospitalization_User_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Hospitalization_PatientFile_PatientFileId` FOREIGN KEY (`PatientFileId`) REFERENCES `PatientFile` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Hospitalization_User_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Hospitalization_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Hospitalization_Room_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Hospitalization_RoomOccupationReportDTO_RoomOccupationReport~` FOREIGN KEY (`RoomOccupationReportDTOId`) REFERENCES `RoomOccupationReportDTO` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Operation` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DoctorId` bigint NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `PeriodId` bigint NULL,
    `RoomId` bigint NULL,
    `PatientId` bigint NULL,
    `PatientFileId` bigint NULL,
    `RoomOccupationReportDTOId` bigint NULL,
    `SecretaryReportDTOId` bigint NULL,
    CONSTRAINT `PK_Operation` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Operation_User_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Operation_PatientFile_PatientFileId` FOREIGN KEY (`PatientFileId`) REFERENCES `PatientFile` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Operation_User_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `User` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Operation_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Operation_Room_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Operation_RoomOccupationReportDTO_RoomOccupationReportDTOId` FOREIGN KEY (`RoomOccupationReportDTOId`) REFERENCES `RoomOccupationReportDTO` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Operation_SecretaryReportDTO_SecretaryReportDTOId` FOREIGN KEY (`SecretaryReportDTOId`) REFERENCES `SecretaryReportDTO` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Renovation` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `Status` int NOT NULL,
    `PeriodId` bigint NULL,
    `RoomId` bigint NULL,
    `RoomOccupationReportDTOId` bigint NULL,
    CONSTRAINT `PK_Renovation` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Renovation_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Renovation_Room_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Room` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Renovation_RoomOccupationReportDTO_RoomOccupationReportDTOId` FOREIGN KEY (`RoomOccupationReportDTOId`) REFERENCES `RoomOccupationReportDTO` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Drug` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Amount` int NOT NULL,
    `Approved` tinyint(1) NOT NULL,
    `DrugId` bigint NULL,
    `PrescriptionId` bigint NULL,
    `TherapyId` bigint NULL,
    CONSTRAINT `PK_Drug` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Drug_Drug_DrugId` FOREIGN KEY (`DrugId`) REFERENCES `Drug` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Drug_Prescription_PrescriptionId` FOREIGN KEY (`PrescriptionId`) REFERENCES `Prescription` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Drug_Therapy_TherapyId` FOREIGN KEY (`TherapyId`) REFERENCES `Therapy` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Ingredient` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Quantity` int NOT NULL,
    `DrugId` bigint NULL,
    CONSTRAINT `PK_Ingredient` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Ingredient_Drug_DrugId` FOREIGN KEY (`DrugId`) REFERENCES `Drug` (`Id`) ON DELETE RESTRICT
);

CREATE INDEX `IX_Address_TownId` ON `Address` (`TownId`);

CREATE INDEX `IX_Allergy_PatientFileId` ON `Allergy` (`PatientFileId`);

CREATE INDEX `IX_Article_DoctorId` ON `Article` (`DoctorId`);

CREATE INDEX `IX_BusinessDay_ShiftId` ON `BusinessDay` (`ShiftId`);

CREATE INDEX `IX_BusinessDay_doctorId` ON `BusinessDay` (`doctorId`);

CREATE INDEX `IX_BusinessDay_roomId` ON `BusinessDay` (`roomId`);

CREATE INDEX `IX_BusinessDayDTO_DoctorId` ON `BusinessDayDTO` (`DoctorId`);

CREATE INDEX `IX_BusinessDayDTO_PeriodId` ON `BusinessDayDTO` (`PeriodId`);

CREATE INDEX `IX_DoctorReportDTO_AnemnesisId` ON `DoctorReportDTO` (`AnemnesisId`);

CREATE INDEX `IX_DoctorReportDTO_PatientId` ON `DoctorReportDTO` (`PatientId`);

CREATE INDEX `IX_DoctorReportDTO_prescriptionId` ON `DoctorReportDTO` (`prescriptionId`);

CREATE INDEX `IX_Drug_DrugId` ON `Drug` (`DrugId`);

CREATE INDEX `IX_Drug_PrescriptionId` ON `Drug` (`PrescriptionId`);

CREATE INDEX `IX_Drug_TherapyId` ON `Drug` (`TherapyId`);

CREATE INDEX `IX_Examination_AnemnesisId` ON `Examination` (`AnemnesisId`);

CREATE INDEX `IX_Examination_DiagnosisId` ON `Examination` (`DiagnosisId`);

CREATE INDEX `IX_Examination_DoctorId` ON `Examination` (`DoctorId`);

CREATE INDEX `IX_Examination_PatientFileId` ON `Examination` (`PatientFileId`);

CREATE INDEX `IX_Examination_PatientId` ON `Examination` (`PatientId`);

CREATE INDEX `IX_Examination_PeriodId` ON `Examination` (`PeriodId`);

CREATE INDEX `IX_Examination_PrescriptionId` ON `Examination` (`PrescriptionId`);

CREATE INDEX `IX_Examination_RefferalId` ON `Examination` (`RefferalId`);

CREATE INDEX `IX_Examination_RoomOccupationReportDTOId` ON `Examination` (`RoomOccupationReportDTOId`);

CREATE INDEX `IX_Examination_RoomOccupationReportDTOId1` ON `Examination` (`RoomOccupationReportDTOId1`);

CREATE INDEX `IX_Examination_SecretaryReportDTOId` ON `Examination` (`SecretaryReportDTOId`);

CREATE INDEX `IX_Examination_TherapyId` ON `Examination` (`TherapyId`);

CREATE INDEX `IX_ExaminationDTO_DoctorId` ON `ExaminationDTO` (`DoctorId`);

CREATE INDEX `IX_ExaminationDTO_PatientId` ON `ExaminationDTO` (`PatientId`);

CREATE INDEX `IX_ExaminationDTO_PeriodId` ON `ExaminationDTO` (`PeriodId`);

CREATE INDEX `IX_ExaminationDTO_RoomId` ON `ExaminationDTO` (`RoomId`);

CREATE INDEX `IX_gradeDTO_DoctorGradeId` ON `gradeDTO` (`DoctorGradeId`);

CREATE INDEX `IX_gradeDTO_DoctorGradeId1` ON `gradeDTO` (`DoctorGradeId1`);

CREATE INDEX `IX_Hospitalization_DoctorId` ON `Hospitalization` (`DoctorId`);

CREATE INDEX `IX_Hospitalization_PatientFileId` ON `Hospitalization` (`PatientFileId`);

CREATE INDEX `IX_Hospitalization_PatientId` ON `Hospitalization` (`PatientId`);

CREATE INDEX `IX_Hospitalization_PeriodId` ON `Hospitalization` (`PeriodId`);

CREATE INDEX `IX_Hospitalization_RoomId` ON `Hospitalization` (`RoomId`);

CREATE INDEX `IX_Hospitalization_RoomOccupationReportDTOId` ON `Hospitalization` (`RoomOccupationReportDTOId`);

CREATE INDEX `IX_Ingredient_DrugId` ON `Ingredient` (`DrugId`);

CREATE INDEX `IX_NotifyDoctorBusinessDay_roomId` ON `NotifyDoctorBusinessDay` (`roomId`);

CREATE INDEX `IX_NotifyDoctorBusinessDay_shiftId` ON `NotifyDoctorBusinessDay` (`shiftId`);

CREATE INDEX `IX_Operation_DoctorId` ON `Operation` (`DoctorId`);

CREATE INDEX `IX_Operation_PatientFileId` ON `Operation` (`PatientFileId`);

CREATE INDEX `IX_Operation_PatientId` ON `Operation` (`PatientId`);

CREATE INDEX `IX_Operation_PeriodId` ON `Operation` (`PeriodId`);

CREATE INDEX `IX_Operation_RoomId` ON `Operation` (`RoomId`);

CREATE INDEX `IX_Operation_RoomOccupationReportDTOId` ON `Operation` (`RoomOccupationReportDTOId`);

CREATE INDEX `IX_Operation_SecretaryReportDTOId` ON `Operation` (`SecretaryReportDTOId`);

CREATE INDEX `IX_PatientNotification_PatientId` ON `PatientNotification` (`PatientId`);

CREATE INDEX `IX_Period_BusinessDayId` ON `Period` (`BusinessDayId`);

CREATE INDEX `IX_Prescription_PeriodId` ON `Prescription` (`PeriodId`);

CREATE INDEX `IX_Referral_DoctorId` ON `Referral` (`DoctorId`);

CREATE INDEX `IX_Referral_PeriodId` ON `Referral` (`PeriodId`);

CREATE INDEX `IX_Renovation_PeriodId` ON `Renovation` (`PeriodId`);

CREATE INDEX `IX_Renovation_RoomId` ON `Renovation` (`RoomId`);

CREATE INDEX `IX_Renovation_RoomOccupationReportDTOId` ON `Renovation` (`RoomOccupationReportDTOId`);

CREATE INDEX `IX_Room_RoomTypeId` ON `Room` (`RoomTypeId`);

CREATE INDEX `IX_RoomOccupationReportDTO_periodId` ON `RoomOccupationReportDTO` (`periodId`);

CREATE INDEX `IX_RoomOccupationReportDTO_roomId` ON `RoomOccupationReportDTO` (`roomId`);

CREATE INDEX `IX_Therapy_PeriodId` ON `Therapy` (`PeriodId`);

CREATE INDEX `IX_Town_StateId` ON `Town` (`StateId`);

CREATE INDEX `IX_User_DoctorGradeId` ON `User` (`DoctorGradeId`);

CREATE INDEX `IX_User_SpecialtyId` ON `User` (`SpecialtyId`);

CREATE INDEX `IX_User_patientFileId` ON `User` (`patientFileId`);

CREATE INDEX `IX_User_AddressId` ON `User` (`AddressId`);

ALTER TABLE `DoctorReportDTO` ADD CONSTRAINT `FK_DoctorReportDTO_Prescription_prescriptionId` FOREIGN KEY (`prescriptionId`) REFERENCES `Prescription` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Examination` ADD CONSTRAINT `FK_Examination_Period_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Period` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Examination` ADD CONSTRAINT `FK_Examination_Prescription_PrescriptionId` FOREIGN KEY (`PrescriptionId`) REFERENCES `Prescription` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Examination` ADD CONSTRAINT `FK_Examination_Therapy_TherapyId` FOREIGN KEY (`TherapyId`) REFERENCES `Therapy` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Examination` ADD CONSTRAINT `FK_Examination_Referral_RefferalId` FOREIGN KEY (`RefferalId`) REFERENCES `Referral` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Examination` ADD CONSTRAINT `FK_Examination_RoomOccupationReportDTO_RoomOccupationReportDTOId` FOREIGN KEY (`RoomOccupationReportDTOId`) REFERENCES `RoomOccupationReportDTO` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Examination` ADD CONSTRAINT `FK_Examination_RoomOccupationReportDTO_RoomOccupationReportDTOI~` FOREIGN KEY (`RoomOccupationReportDTOId1`) REFERENCES `RoomOccupationReportDTO` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Period` ADD CONSTRAINT `FK_Period_BusinessDay_BusinessDayId` FOREIGN KEY (`BusinessDayId`) REFERENCES `BusinessDay` (`Id`) ON DELETE RESTRICT;
