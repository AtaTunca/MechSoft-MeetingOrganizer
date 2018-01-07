using MeetingOrganizer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingOrganizer.Controllers
{
    public class HomeController : Controller
    {

        public class MeetingVM
        {
            public string MeetingID { get; set; }

            [Required]
            public string MeetingSubject { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public string Date { get; set; }

            [Required]
            [DataType(DataType.Time)]
            public string StartingTime { get; set; }


            [Required]
            [DataType(DataType.Time)]
            public string EndingTime { get; set; }

            [Required]
            public string Participants { get; set; }


        }


        // GET: Home
        public ActionResult Index()
        {
            using (MeetingOrganizerEntities db = new MeetingOrganizerEntities())
            {

                var model2 = db.Meeting.ToList();

                List<Meeting> model = new List<Meeting>(model2.Count);

                for (int i = 0; i < model2.Count; i++)
                {
                    Meeting List = new Meeting()
                    {
                        MeetingID = model2[i].MeetingID,
                        MeetingSubject = model2[i].MeetingSubject,
                        StartingTime = model2[i].StartingTime,
                        EndingTime = model2[i].EndingTime,
                        Participants = model2[i].Participants,
                        Date = model2[i].Date


                    };

                    model.Add(List);

                }

                return View(model);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMeeting(MeetingVM model)
        {
            if (ModelState.IsValid)
            {
                Meeting m = new Meeting();

                m.MeetingSubject = model.MeetingSubject;
                m.Date = Convert.ToDateTime(model.Date);
                m.StartingTime = TimeSpan.Parse(model.StartingTime);
                m.EndingTime = TimeSpan.Parse(model.EndingTime);
                m.Participants = model.Participants;



                using (MeetingOrganizerEntities db = new MeetingOrganizerEntities())
                {
                    db.Meeting.Add(m);
                    db.SaveChanges();




                }

            }

            return Redirect("/Home/Index");
        }
        public ActionResult DeleteMeeting(string id)
        {

            var newid = Int32.Parse(id);


            using (MeetingOrganizerEntities db = new MeetingOrganizerEntities())
            {

                Meeting mt = db.Meeting.Find(newid);

                db.Meeting.Remove(mt);
                db.SaveChanges();


                return Redirect("/Home/Index");
            }



        }
        public ActionResult UpdateMeeting(string id)
        {

            var newid = Int32.Parse(id);


            using (MeetingOrganizerEntities db = new MeetingOrganizerEntities())
            {

                var model = db.Meeting.FirstOrDefault(x => x.MeetingID == newid);

                return View(model);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MeetingVM Meeting)
        {

            var newid = Int32.Parse(Meeting.MeetingID);


            using (MeetingOrganizerEntities db = new MeetingOrganizerEntities())
            {

                var model = db.Meeting.FirstOrDefault(x => x.MeetingID == newid);

                model.MeetingSubject = Meeting.MeetingSubject;
                model.StartingTime = TimeSpan.Parse(Meeting.StartingTime);
                model.EndingTime = TimeSpan.Parse(Meeting.StartingTime);
                model.Date = Convert.ToDateTime(Meeting.Date);
                model.Participants = Meeting.Participants;

                db.SaveChanges();

                return Redirect("/Home/Index");

            }



        }

    }
}