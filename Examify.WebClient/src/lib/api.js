import Axios from 'axios';
import Cookies from 'js-cookie';
import { BACKEND_ENDPOINT } from '~/config/env';

function authRequestInterceptor(config) {
  if (config.headers) {
    let token = Cookies.get('token');
    config.headers.Accept = 'application/json';
    config.headers['Authorization'] = `Bearer ${token || ''}`;
  }
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
    return Promise.reject(error);
  },
);
