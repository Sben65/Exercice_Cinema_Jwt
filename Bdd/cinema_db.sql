#------------------------------------------------------------
# Table: Users
#------------------------------------------------------------

CREATE TABLE Users(
        id       Int  Auto_increment  NOT NULL ,
        username Varchar (100) NOT NULL ,
        password Varchar (250) NOT NULL
	,CONSTRAINT Users_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Film
#------------------------------------------------------------

CREATE TABLE Film(
        id     Int  Auto_increment  NOT NULL ,
        nom    Varchar (150) NOT NULL ,
        duree  Double NOT NULL ,
        imgUrl Varchar (250) NOT NULL
	,CONSTRAINT Film_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Review
#------------------------------------------------------------

CREATE TABLE Review(
        id       Int  Auto_increment  NOT NULL ,
        text     Text NOT NULL ,
        id_Film  Int NOT NULL ,
        id_Users Int NOT NULL
	,CONSTRAINT Review_PK PRIMARY KEY (id)

	,CONSTRAINT Review_Film_FK FOREIGN KEY (id_Film) REFERENCES Film(id)
	,CONSTRAINT Review_Users0_FK FOREIGN KEY (id_Users) REFERENCES Users(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Cinema
#------------------------------------------------------------

CREATE TABLE Cinema(
        id  Int  Auto_increment  NOT NULL ,
        nom Varchar (150) NOT NULL
	,CONSTRAINT Cinema_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Salle
#------------------------------------------------------------

CREATE TABLE Salle(
        id            Int  Auto_increment  NOT NULL ,
        numero        Int NOT NULL ,
        nbPlaceAssise Int NOT NULL ,
        id_Cinema     Int NOT NULL
	,CONSTRAINT Salle_PK PRIMARY KEY (id)

	,CONSTRAINT Salle_Cinema_FK FOREIGN KEY (id_Cinema) REFERENCES Cinema(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Seances
#------------------------------------------------------------

CREATE TABLE Seances(
        id        Int  Auto_increment  NOT NULL ,
        id_Film   Int NOT NULL ,
        id_Salle  Int NOT NULL ,
        id_Cinema Int NOT NULL
	,CONSTRAINT Seances_PK PRIMARY KEY (id)

	,CONSTRAINT Seances_Film_FK FOREIGN KEY (id_Film) REFERENCES Film(id)
	,CONSTRAINT Seances_Salle0_FK FOREIGN KEY (id_Salle) REFERENCES Salle(id)
	,CONSTRAINT Seances_Cinema1_FK FOREIGN KEY (id_Cinema) REFERENCES Cinema(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Ticket
#------------------------------------------------------------

CREATE TABLE Ticket(
        id         Int  Auto_increment  NOT NULL ,
        id_Seances Int NOT NULL ,
        id_Users   Int NOT NULL
	,CONSTRAINT Ticket_PK PRIMARY KEY (id)

	,CONSTRAINT Ticket_Seances_FK FOREIGN KEY (id_Seances) REFERENCES Seances(id)
	,CONSTRAINT Ticket_Users0_FK FOREIGN KEY (id_Users) REFERENCES Users(id)
)ENGINE=InnoDB;