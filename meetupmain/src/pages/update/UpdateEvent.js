import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";
import { CategoryService } from "../../services/category.service";
import { EventService } from "../../services/event.service";
import UpdateEventView from "./UpdateEventView";
import { useParams } from "react-router-dom";

const UpdateEvent = () => {
  const id = useParams().id;
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(CategoryService.getCategories());
    dispatch(EventService.getEventWithDetail(id));
  }, [dispatch]);

  const onSubmit = (data) => {
    dispatch(EventService.updateEvent(data));
  };

  return <UpdateEventView onSubmit={onSubmit} />;
};
export default UpdateEvent;
