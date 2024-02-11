using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using KayakTracker.Application.DTOs;
using KayakTracker.Domain.Enums;
using KayakTracker.Domain.Models;
using KayakTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;

namespace KayakTracker.Application.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<List<TripDto>> GetTripList(string userName)
        {
            var list = new List<TripDto>();

            var trips = await _tripRepository.GetTrips(userName);

            var tripsDTOs = _mapper.Map<List<TripDto>>(trips);
            list.AddRange(tripsDTOs);

            return list;
        }

        public async Task<List<Trip>> Import(IFormFile file, string userId)
        {
            try
            {
                var trips = new List<Trip>();

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                };

                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    ms.Position = 0;

                    using (var reader = new StreamReader(ms))
                    {
                        using (var csv = new CsvReader(reader, config))
                        {
                            var parsedRecords = csv.GetRecords<TripImportDto>().ToList();

                            foreach (var tripDto in parsedRecords)
                            {
                                var trip = new Trip
                                {
                                    State = getState(tripDto.State),
                                    River = getRiver(tripDto.River, getState(tripDto.State)),   

                                    Stage = tripDto.Stage,
                                    StartName = tripDto.StartName,
                                    StartCoordinates = tripDto.StartCoordinates,
                                    EndCoordinates = tripDto.EndCoordinates,
                                    EndName = tripDto.EndName,
                                    MeasuredAt = tripDto.MeasuredAt,
                                    Notes = tripDto.Notes,
                                    OwnerId = userId
                                };

                                // year
                                //date
                                DateTime date;
                                int year;

                                if (DateTime.TryParse(tripDto.DateString, out date))
                                {
                                    trip.StartDate = date.ToUniversalTime();
                                }
                                else if (Int32.TryParse(tripDto.DateString, out year))
                                {
                                    trip.StartDate = new DateTime(year, 1, 1).ToUniversalTime();
                                }
                                else if (!String.IsNullOrEmpty(tripDto.DateString))
                                {
                                    string[] s = tripDto.DateString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                    if (Int32.TryParse(s.Last(), out year))
                                    {
                                        trip.StartDate = new DateTime(year, 1, 1).ToUniversalTime();
                                    }
                                }

                                //flow
                                if (!string.IsNullOrEmpty(tripDto.FlowString))
                                {
                                    string flowNumber = tripDto.FlowString.ToLower().Replace("cfs", "").Trim();
                                    double flow;
                                    if (Double.TryParse(flowNumber, out flow))
                                    {
                                        trip.Flow = flow;
                                    }
                                }

                                //time minues
                                if (!string.IsNullOrEmpty(tripDto.TimeString))
                                {
                                    int minutes;
                                    int hours;
                                    trip.TimeMinutes = 0;

                                    var timeString = tripDto.TimeString.ToLower().Replace("~", "").Replace("hours", "hr").
                                        Replace("hrs", "hr").Replace("?", "").Replace(" ", "").Trim(); ;

                                    var s = timeString.Split(new[] { "hr", "min" }, StringSplitOptions.RemoveEmptyEntries);

                                    if (Int32.TryParse(s[0], out hours))
                                    {
                                        trip.TimeMinutes += (hours * 60);
                                    }

                                    if (s.Length > 1)
                                    {
                                        if (Int32.TryParse(s[1], out minutes))
                                        {
                                            trip.TimeMinutes += minutes;
                                        }
                                    }
                                }

                                //distance miles
                                double miles;
                                if (Double.TryParse(tripDto.DistanceMiles, out miles))
                                {
                                    trip.DistanceMiles = miles;
                                }

                                trips.Add(trip);
                            }

                            await _tripRepository.SaveTrips(trips);

                            return trips;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private River getRiver(string river, StateEnum state)
        {
            return _tripRepository.GetRiver(river, state);
        }

        private StateEnum getState(string stateName)
        {
            foreach (StateEnum state in Enum.GetValues(typeof(StateEnum)))
            {
                if (state.ToString() == stateName.ToUpper())
                {
                    return state;
                }
            }

            throw new ArgumentException("No matching state for abbreviation: " + stateName);

        }
    }
}
