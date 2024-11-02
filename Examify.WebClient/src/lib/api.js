import Axios from 'axios';
import Cookies from 'cookies';
import { BACKEND_ENDPOINT } from '~/config/env';

function authRequestInterceptor(config) {
  if (config.headers) {
    var cookies = new Cookies()
    let token = cookies.get('token');
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    config.headers.Accept = 'application/json';
  }

  // config.withCredentials = true;
  return config;
}

export const api = Axios.create({
  baseURL: BACKEND_ENDPOINT,
});

api.interceptors.request.use(authRequestInterceptor);
api.interceptors.response.use(
  (response) => {
    return response.data;
  },
  (error) => {
    console.log(error);
    // if (error.response?.status === 401) {
    //   const searchParams = new URLSearchParams();
    //   const redirectTo = searchParams.get('redirectTo');
    //   window.location.href = `/auth/login?redirectTo=${redirectTo}`;
    // }

    return Promise.reject(error);
  },
);
