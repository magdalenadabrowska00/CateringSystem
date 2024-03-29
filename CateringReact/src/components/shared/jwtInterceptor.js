import axios from "axios";

const jwtInterceptor = axios.create({});

jwtInterceptor.interceptors.request.use((config) => {
  let tokenData = JSON.parse(localStorage.getItem("token"));
  config.headers.Authorization = `Bearer ${tokenData.token}`;
  return config;
});

export default jwtInterceptor;
