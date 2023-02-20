import { createSlice } from "@reduxjs/toolkit";
import { EventService } from "../../services/event.service";

const initialState = {
  events: [],
  eventAttendees: [],
  favEvents: [],
  attendedEvents: [],
  postedEvents: [],
  isLoading: false,
  hasError: false,
};

const eventSlice = createSlice({
  name: "eventSlice",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(EventService.getEvents.pending, (state, action) => {
        state.isLoading = true;
        state.hasError = false;
      })
      .addCase(EventService.getEvents.fulfilled, (state, action) => {
        state.events = action.payload;
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(EventService.getEvents.rejected, (state, action) => {
        state.hasError = true;
        state.isLoading = false;
      })
      .addCase(
        EventService.getEventWithDetailById.fulfilled,
        (state, action) => {
          state.events = action.payload;
          state.isLoading = false;
          state.hasError = false;
        }
      )
      .addCase(EventService.getEventsByTagName.fulfilled, (state, action) => {
        state.events = action.payload;
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(
        EventService.getEventsByCategoryName.fulfilled,
        (state, action) => {
          state.events = action.payload;
          state.isLoading = false;
          state.hasError = false;
        }
      )
      .addCase(
        EventService.getEventsByCategoryId.fulfilled,
        (state, action) => {
          state.events = action.payload;
          state.isLoading = false;
          state.hasError = false;
        }
      )
      .addCase(EventService.searchEvents.fulfilled, (state, action) => {
        state.events = action.payload;
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(EventService.getEventWithDetail.fulfilled, (state, action) => {
        state.events = action.payload;
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(EventService.attendToEvent.fulfilled, (state) => {
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(EventService.getEventAttendees.fulfilled, (state, action) => {
        state.eventAttendees = action.payload;
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(EventService.createEvent.fulfilled, (state, action) => {
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(EventService.deleteFavEvent.fulfilled, (state, action) => {
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(EventService.getFavEvents.fulfilled, (state, action) => {
        state.isLoading = false;
        state.hasError = false;
        state.favEvents = action.payload;
      })
      .addCase(
        EventService.getUserAttendedEvents.fulfilled,
        (state, action) => {
          state.isLoading = false;
          state.hasError = false;
          state.attendedEvents = action.payload;
        }
      )
      .addCase(EventService.getUserPostedEvents.fulfilled, (state, action) => {
        state.isLoading = false;
        state.hasError = false;
        state.postedEvents = action.payload;
      })
      .addCase(EventService.deletePostedEvent.fulfilled, (state, action) => {
        state.isLoading = false;
        state.hasError = false;
        state.postedEvents = action.payload;
      });
  },
});

export const selectEvents = (state) => state.eventSlice.events;
export const selectEventAttendees = (state) => state.eventSlice.eventAttendees;
export const selectFavEvents = (state) => state.eventSlice.favEvents;
export const selectAttendedEvents = (state) => state.eventSlice.attendedEvents;
export const selectPostedEvents = (state) => state.eventSlice.postedEvents;
export const selectLoadingState = (state) => state.eventSlice.isLoading;
export const selectErrorState = (state) => state.eventSlice.hasError;
export default eventSlice.reducer;
