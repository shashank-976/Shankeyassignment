using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using EntityLayer;
using static ReservationSystem.Models.GuestSort;

namespace ReservationSystem.Models
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
       public List<ReservationModel> displayReservation()
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


        public List<GuestModel> displayGuest()
        {
            Business business = new Business();
            List<Guest> guests = business.displayGuest();
            List<GuestModel> guestModels = new List<GuestModel>();
            foreach (var guest1 in guests)
            {
                GuestModel guestModel = new GuestModel();
                guestModel.GuestId = guest1.GuestId;
                guestModel.GuestName = guest1.GuestName;
                guestModel.TableforPeople = guest1.TableforPeople;
                guestModel.ReservationId = guest1.ReservationId;
                guestModels.Add(guestModel);
            }
            return guestModels;
        }


        public List<GuestModel> displayLGuest()
        {
            Business business = new Business();
            List<Guest> guests = business.displayLGuest();
            List<GuestModel> guestModels = new List<GuestModel>();
            foreach (var guest1 in guests)
            {
                GuestModel guestModel = new GuestModel();
                guestModel.GuestId = guest1.GuestId;
                guestModel.GuestName = guest1.GuestName;
                guestModel.TableforPeople = guest1.TableforPeople;
                guestModel.ReservationId = guest1.ReservationId;
                guestModels.Add(guestModel);
            }
            return guestModels;
        }

        public List<GuestModel> displayGuestId()
        {
            GetAllId getAllId = new GetAllId();
            List<GuestSort> guestSorts = new List<GuestSort>();
            List<GuestModel> guestModels = new List<GuestModel>();
            guestSorts = getAllId.guestT();
            foreach(var item in guestSorts)
            {
                GuestModel guestModel = new GuestModel();
                guestModel.GuestId = item.GuestId;
                guestModel.GuestName = item.GuestName;

                guestModel.TableforPeople = item.TableforPeople;
                guestModel.ReservationId = item.ReservationId;
                guestModels.Add(guestModel);
            }
            return guestModels;
        }


        public List<GuestModel> displayNames()
        {
            Business business = new Business();
            List<Guest> guests = business.displayNames();
            List<GuestModel> guestModels = new List<GuestModel>();
            foreach (var guest1 in guests)
            {
                GuestModel guestModel = new GuestModel();
                guestModel.GuestId = guest1.GuestId;
                guestModel.GuestName = guest1.GuestName;
                guestModel.TableforPeople = guest1.TableforPeople;
                guestModel.ReservationId = guest1.ReservationId;
                guestModels.Add(guestModel);
            }
            return guestModels;
        }

        public void UpdateBillDetails(GuestModel guestModel,int id)
        {
            Guest guest = new Guest();
            Business business = new Business();
            guest.GuestId = guestModel.GuestId;
            guest.GuestName = guestModel.GuestName;
            guest.BillAmount = guestModel.BillAmount;
            guest.TableforPeople = guestModel.TableforPeople;
            guest.ReservationId = guestModel.ReservationId;

            business.UpdateBillDetails(guest,id);

        }


    }
    }