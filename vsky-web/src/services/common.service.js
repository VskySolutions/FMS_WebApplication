import { http } from "boot/axios";

export default {
  getCountries () {
    return http.get("/common/countries").then(response => response.data);
  },

  getStates (countryId) {
    return http.get(`/common/state-provinces?countryId=${countryId}`).then(response => response.data);
  },

  getPicture (pictureId) {
    return http.get(`/common/picture?pictureId=${pictureId}`).then(response => response.data);
  },

  sendContactUs (model) {
    return http.post("/common/send-contactus-email", model).then(response => response.data);
  },
  getContactUsEnquiries (payload) {
    return http.post("/common/contact-us-enquiries", { params: payload }).then(response => response.data);
  }
};
