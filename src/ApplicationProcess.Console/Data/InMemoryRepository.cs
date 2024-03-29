﻿using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationProcess.Console.Entities;

namespace ApplicationProcess.Console.Data
{
    /// <summary>
    /// Memory storage for application process.
    /// </summary>
    public class InMemoryRepository : IApplicationRepository
    {
        private readonly IList<Mentor> _mentors;
        private readonly IList<Applicant> _applicants;
        private readonly IList<Application> _applications;
        private readonly IList<School> _schools;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryRepository"/> class.
        /// </summary>
        public InMemoryRepository()
        {
            _mentors = new List<Mentor>();
            _applicants = new List<Applicant>();
            _applications = new List<Application>();
            _schools = new List<School>();

            Seed();
        }

        /// <inheritdoc/>
        public int AmountOfApplicationAfter(DateTime date)
        {
            IEnumerable<Application> result =
                from application in _applications
                where application.ApplicationDate > date
                select application;

            return result.Count();
        }

        /// <inheritdoc/>
        public IEnumerable<Mentor> GetAllMentorFrom(City city)
        {
            IEnumerable<Mentor> mentorsByCity =
                from mentor in _mentors
                where mentor.City == city
                select mentor;

            return mentorsByCity;
        }

        /// <inheritdoc/>
        public IEnumerable<Mentor> GetAllMentorWhomFavoriteLanguage(string language)
        {
            IEnumerable<Mentor> result =
                from mentor in _mentors
                where mentor.ProgrammingLanguage == language
                select mentor;

            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<Applicant> GetApplicantsOf(string contactMentorName)
        {
            IEnumerable<Application> applications =
                from application in _applications
                where application.Mentor.FirstName == contactMentorName
                select application;

            IEnumerable<Applicant> result =
                from application in applications
                select application.Applicant;

            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetAppliedStudentEmailList()
        {
            IEnumerable<string> result =
                from applicant in _applicants
                select applicant.Email;

            return result;
        }

        /// <summary>
        /// Seed memory storage with sample data.
        /// </summary>
        private void Seed()
        {
            #region Seed Mentors
            Mentor atesz = new Mentor("Attila", "Molnár")
            {
                Nickname = "Atesz",
                City = City.Budapest,
                PhoneNumber = "123456789",
                ProgrammingLanguage = "C#"
            };
            Mentor matyi = new Mentor("Mátyás", "Fórián-Szabó")
            {
                Nickname = "Matyi",
                City = City.Budapest,
                PhoneNumber = "987654321",
                ProgrammingLanguage = "Java"
            };
            Mentor belian = new Mentor("Belián", "Radosza")
            {
                City = City.Budapest,
                PhoneNumber = "123498765",
                ProgrammingLanguage = "C#"
            };
            Mentor miki = new Mentor("Miklós", "Beöthy")
            {
                Nickname = "Miki",
                City = City.Budapest,
                PhoneNumber = "987766789",
                ProgrammingLanguage = "Ruby"
            };
            Mentor pal = new Mentor("Pál", "Monoczki")
            {
                Nickname = "Pakko",
                City = City.Miskolc,
                PhoneNumber = "5432198765",
                ProgrammingLanguage = "C#"
            };
            Mentor robi = new Mentor("Róbert", "Kohányi")
            {
                Nickname = "Robi",
                City = City.Miskolc,
                PhoneNumber = "123454321",
                ProgrammingLanguage = "Java"
            };
            Mentor mati = new Mentor("Mateus", "Ostafil")
            {
                Nickname = "Mati",
                City = City.Krakow,
                PhoneNumber = "453454321",
                ProgrammingLanguage = "Javascript"
            };
            _mentors.Add(atesz);
            _mentors.Add(matyi);
            _mentors.Add(belian);
            _mentors.Add(miki);
            _mentors.Add(pal);
            _mentors.Add(robi);
            _mentors.Add(mati);
            #endregion

            #region Seed Schools
            _schools.Add(new School("Codecool Miskolc", City.Miskolc, "Hungary"));
            _schools.Add(new School("Codecool Budapest", City.Budapest, "Hungary"));
            _schools.Add(new School("Codecool Krakow", City.Krakow, "Poland"));
            _schools.Add(new School("Codecool Warsaw", City.Warsaw, "Poland"));
            _schools.Add(new School("Codecool Bucharest", City.Bucharest, "Romania"));
            #endregion

            #region Seed Applicants
            Applicant dominik = new Applicant("Dominique", "Williams")
            {
                PhoneNumber = "003630/734-4926",
                Email = "dolor@laoreet.co.uk",
                Status = ApplicationStatus.Applied
            };
            Applicant jemima = new Applicant("Jemima", "Foreman")
            {
                PhoneNumber = "003620/834-6898",
                Email = "magna@etultrices.net",
                Status = ApplicationStatus.Applied
            };
            Applicant zeph = new Applicant("Zeph", "Massey")
            {
                PhoneNumber = "003630/216-5351",
                Email = "a.feugiat.tellus@montesnasceturridiculus.co.uk",
                Status = ApplicationStatus.Approved,
                StartDate = new DateTime(2019, 1, 1)
            };
            Applicant joseph = new Applicant("Joseph", "Crawford")
            {
                PhoneNumber = "003670/923-2669",
                Email = "lacinia.mattis@arcu.co.uk",
                Status = ApplicationStatus.Approved,
                StartDate = new DateTime(2019, 1, 1)
            };
            Applicant ifeoma = new Applicant("Ifeoma", "Bird")
            {
                PhoneNumber = "003630/465-8994",
                Email = "diam.duis.mi@orcitinciduntadipiscing.com",
                Status = ApplicationStatus.Approved,
                StartDate = new DateTime(2019, 1, 1)
            };
            Applicant jemi = new Applicant("Jemima", "Cantu")
            {
                PhoneNumber = "003620/804-1652",
                Email = "semper.pretium.neque@mauriseu.net",
                Status = ApplicationStatus.Applied
            };
            Applicant carol = new Applicant("Carol", "Arnold")
            {
                PhoneNumber = "003620/423-4261",
                Email = "et.risus.quisque@mollis.co.uk",
                Status = ApplicationStatus.Recejted
            };
            Applicant jane = new Applicant("Jane", "Forbes")
            {
                PhoneNumber = "003630/179-1827",
                Email = "dapibus.rutrum@litoratorquent.com",
                Status = ApplicationStatus.Cancelled
            };
            Applicant ursa = new Applicant("Ursa", "William")
            {
                PhoneNumber = "003670/653-5392",
                Email = "janiebaby@adipiscingenimmi.edu",
                Status = ApplicationStatus.Approved,
                StartDate = new DateTime(2019, 5, 2)
            };
            _applicants.Add(dominik);
            _applicants.Add(jemima);
            _applicants.Add(zeph);
            _applicants.Add(joseph);
            _applicants.Add(ifeoma);
            _applicants.Add(jemi);
            _applicants.Add(carol);
            _applicants.Add(jane);
            _applicants.Add(ursa);
            #endregion

            #region Seed Applications
            _applications.Add(new Application(atesz, dominik, new DateTime(2018, 9, 1)));
            _applications.Add(new Application(atesz, jemima, new DateTime(2018, 9, 1)));
            _applications.Add(new Application(atesz, zeph, new DateTime(2018, 9, 1)));
            _applications.Add(new Application(atesz, joseph, new DateTime(2018, 8, 1)));
            _applications.Add(new Application(atesz, ifeoma, new DateTime(2018, 8, 1)));
            _applications.Add(new Application(atesz, jemi, new DateTime(2018, 9, 1)));
            _applications.Add(new Application(atesz, carol, new DateTime(2018, 9, 1)));
            _applications.Add(new Application(atesz, jane, new DateTime(2019, 1, 1)));
            _applications.Add(new Application(atesz, ursa, new DateTime(2019, 1, 1)));
            #endregion
        }

        private void SerializeObjectsToXml()
        {
            foreach (var mentor in _mentors)
            {
                mentor.Serialize();
            }

            foreach (var school in _schools)
            {
                school.Serialize();
            }

            foreach (var applicant in _applicants)
            {
                applicant.Serialize();
            }

            foreach (var application in _applications)
            {
                application.Serialize();
            }
        }
    }
}
