using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoApi.Models
{
    public class ModelManager
    {
        public void addGuest(GuestModel guestModel)
        {

            Guest guest = new Guest();
            guest.GuestName = guestModel.GuestName;
            guest.TableforPeople = guestModel.TableforPeople;
            guest.BillAmount = guestModel.BillAmount;
            guest.ReservationId = guestModel.ReservationId;


            Business business = new Business();
            business.addGuest(guest);
        }

        public object displayReservation()
        {
            Business business = new Business();
            List<Reservation> reservations = business.displayReservation();
            List<ReservationModel> reservationModels = new List<ReservationModel>();
            foreach (var guest1 in reservations)
            {
                ReservationModel reservationModel = new ReservationModel();
                reservationModel.ReservationId = guest1.ReservationId;
                reservationModel.Status = guest1.Status;
                reservationModels.Add(reservationModel);
            }
            return reservationModels;
        }
    }
    }
