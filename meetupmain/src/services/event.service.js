import { createAsyncThunk } from "@reduxjs/toolkit";
import { axiosApiInstance } from "./axios.base.service";

export const EventService = {};

EventService.getEvents = createAsyncThunk("EventSlice/getEvents", async () => {
  try {
    const response = await axiosApiInstance.get("/api/Event");
    return response.data;
  } catch (error) {
    console.error(error);
  }
});

EventService.getEventWithDetailById = createAsyncThunk(
  "EventSlice/getEventWithDetailById",
  async (eventId) => {
    try {
      const response = await axiosApiInstance.get(
        `/api/Event/with-detail/${eventId}`,
        { eventId },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.getEventsByTagName = createAsyncThunk(
  "EventSlice/getEventsByTagName",
  async (name) => {
    try {
      const response = await axiosApiInstance.get(
        `/api/Event/byTagName?Name=${name}`,
        {
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            name: typeof name === "string" ? name.toString() : "",
          }),
        }
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.getEventsByCategoryName = createAsyncThunk(
  "EventSlice/getEventsByCategoryName",
  async (categoryName) => {
    try {
      const response = await axiosApiInstance.get(
        `/api/Event/by-category-name?CategoryName=${categoryName}`,
        {
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            categoryName:
              typeof categoryName === "string" ? categoryName.toString() : "",
          }),
        }
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.getEventsByCategoryId = createAsyncThunk(
  "EventSlice/getEventsByCategoryId",
  async (id) => {
    try {
      const response = await axiosApiInstance.get(
        `/api/Event/by-category-id/${id}`,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.searchEvents = createAsyncThunk(
  "EventSlice/searchEvents",
  async ({ place, tag, category, title, startDate, endDate }) => {
    console.log(
      "🚀 ~ file: event.service.js:102 ~ place, tagName, categoryName, title, startDate, endDate",
      place,
      tag,
      category,
      title,
      startDate,
      endDate
    );
    try {
      place = place || "";
      tag = tag || "";
      category = category || "";
      title = title || "";
      startDate = startDate || "";
      endDate = endDate || "";
      const response = await axiosApiInstance.get(
        `/api/Event/search?Place=${place}&TagName=${tag}&CategoryName=${category}&Title=${title}&EndDate=${endDate}&StartDate=${startDate}`,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.getEventWithDetail = createAsyncThunk(
  "EventSlice/getEventWithDetail",
  async (id) => {
    try {
      const response = await axiosApiInstance.get(`/api/Event/${id}`, {
        headers: {
          "Content-Type": "application/json",
        },
      });
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.addFav = createAsyncThunk("EventSlice/addFav", async (id) => {
  try {
    const response = await axiosApiInstance.post(
      `/api/FavoriteEvent/fav/${id}`
    );
    return response.data;
  } catch (error) {
    console.error(error);
  }
});

EventService.attendToEvent = createAsyncThunk(
  "EventSlice/attendToEvent",
  async (id) => {
    try {
      const response = await axiosApiInstance.post(
        `/api/AttendedEvent/attend/${id}`
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.getEventAttendees = createAsyncThunk(
  "EventSlice/getEventAttendees",
  async (id) => {
    try {
      const response = await axiosApiInstance.get(
        `/api/AttendedEvent/event-attendees/${id}`
      );
      console.log("eventservice", response.data);
      return response.data.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.createEvent = createAsyncThunk(
  "EventSlice/createEvent",
  async ({
    title,
    shortContent,
    imageUrl,
    capacity,
    content,
    place,
    tags,
    categoryId,
    startDate,
    endDate,
  }) => {
    try {
      const response = await axiosApiInstance.post(`/api/Event`, {
        title,
        shortContent,
        imageUrl,
        capacity,
        content,
        place,
        tags,
        categoryId,
        startDate,
        endDate,
      });
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.deleteFavEvent = createAsyncThunk(
  "EventSlice/deleteFavEvent",
  async (id) => {
    try {
      const response = await axiosApiInstance.delete(
        `/api/FavoriteEvent/delete-fav/${id}`
      );
      return response.data.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.getFavEvents = createAsyncThunk(
  "EventSlice/getFavEvents",
  async () => {
    try {
      const response = await axiosApiInstance.get(
        `/api/FavoriteEvent/user-favs`
      );
      console.log(
        "🚀 ~ file: event.service.js:236 ~ response.data",
        response.data
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.getUserAttendedEvents = createAsyncThunk(
  "EventSlice/getUserAttendedEvents",
  async () => {
    try {
      const response = await axiosApiInstance.get(
        `/api/AttendedEvent/user-attended`
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.getUserPostedEvents = createAsyncThunk(
  "EventSlice/getUserPostedEvents",
  async () => {
    try {
      const response = await axiosApiInstance.get(`/api/User/user-posted`);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

EventService.deletePostedEvent = createAsyncThunk(
  "EventSlice/deletePostedEvent",
  async (id) => {
    try {
      console.log("🚀");
      await axiosApiInstance.delete(`/api/Event/${id}`);
      const response = await axiosApiInstance.get(`/api/User/user-posted`);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);
