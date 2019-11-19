using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rezerwacja_pokoi.Data;
using Rezerwacja_pokoi.Models;

namespace Rezerwacja_pokoi.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly HotelContext _context;

        public ReservationsController(HotelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Reservations.Include(r => r.Payment).Include(r => r.Room).Include(r => r.User);
            return View(await hotelContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Payment)
                .Include(r => r.Room)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        public IActionResult Create()
        {
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID");
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,RoomID,PaymentID,ChosenConvID,DateFrom,DateTo,Confirmed,Feedback")] Reservation reservation)
        {
            var availableRooms = _context.Rooms.Where(m => m.Reservations.All(r => r.DateTo <= reservation.DateFrom || r.DateFrom >= reservation.DateTo));

            if (!availableRooms.Any(m=> m.RoomID == reservation.RoomID))
            {
                ModelState.AddModelError("","Nie można dokonać rezerwacji w tym okresie ponieważ pokój jest zajety.");
            }
         
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", reservation.PaymentID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID", reservation.RoomID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email", reservation.UserID);
            return View(reservation);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", reservation.PaymentID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID", reservation.RoomID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email", reservation.UserID);
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,RoomID,PaymentID,ChosenConvID,DateFrom,DateTo,Confirmed,Feedback")] Reservation reservation)
        {
            if (id != reservation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentID"] = new SelectList(_context.Payments, "PaymentID", "PaymentID", reservation.PaymentID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID", reservation.RoomID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email", reservation.UserID);
            return View(reservation);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Payment)
                .Include(r => r.Room)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ID == id);
        }

    }
}
