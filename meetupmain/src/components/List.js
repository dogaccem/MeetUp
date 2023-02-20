import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { selectEvents } from "../features/events/eventSlice";
import { EventService } from "../services/event.service";
import EventCard from "./EventCard";

const List = ({ data }) => {
  const eventResponse = useSelector(selectEvents);
  console.log("🚀 ~ file: List.js:9 ~ List ~ eventResponse", eventResponse);
  const events = eventResponse?.data || [];
  console.log("🚀 ~ file: List.js:16 ~ useEffect ~ data.catId", data.catId);
  const dispatch = useDispatch();
  useEffect(() => {
    if (data.catId) {
      dispatch(EventService.getEventsByCategoryId(data.catId));
    }

    dispatch(EventService.getEvents());
  }, [data.catId, dispatch]);

  return (
    <div>
      {events?.map((eventItem) => (
        <EventCard item={eventItem} key={eventItem.id} />
      ))}
    </div>
  );
};

export default List;
