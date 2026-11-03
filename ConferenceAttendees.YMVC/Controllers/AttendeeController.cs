using ConferenceAttendees.YMVC.Models;
using ConferenceAttendees.YMVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceAttendees.YMVC.Controllers
{
    public class AttendeeController(IClient client, ILogger<HomeController> logger) : Controller
    {
        private readonly IClient client = client;
        private readonly ILogger<HomeController> logger = logger;

        // GET: AttendeeController
        public async Task<ActionResult> Index()
        {
            var attendees = await client.AttendeesAllAsync();
            return View(attendees);
        }

        // GET: AttendeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AttendeeController/Create
        public async Task<ActionResult> Create()
        {
            await SetNomenclature();

            return View();
        }

        private async Task SetNomenclature()
        {
            ViewData["Genders"] = await client.GendersAllAsync();
            ViewData["JobRoles"] = await client.JobRolesAllAsync();
            ViewData["RefSources"] = await client.ReferralSourcesAllAsync();
        }

        // POST: AttendeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AttendeeDto attendeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            Attendee attendee = new Attendee
            {
                FirstName = attendeeDto.FirstName,
                LastName = attendeeDto.LastName,
                EmailAddress = attendeeDto.EmailAddress,
                PhoneNumber = attendeeDto.PhoneNumber,
                CompanyName = attendeeDto.CompanyName,
                ReferralSourceId = attendeeDto.ReferralSourceId,
                JobRoleId = attendeeDto.JobRoleId,
                GenderId = attendeeDto.GenderId
            };

            try
            {
                var result = await client.AttendeesPOSTAsync(attendee);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating attendee.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the attendee. Please try again.");

                await SetNomenclature();
                return View(attendeeDto);
            }
        }

        // GET: AttendeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AttendeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Attendee attendee)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AttendeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AttendeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
