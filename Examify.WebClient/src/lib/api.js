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

async function refreshAccessToken() {
  let refreshTokenLocal = Cookies.get('refreshToken');
  if (!refreshTokenLocal) {
    return;
  }

  try {
    const response = await Axios.post(`${BACKEND_ENDPOINT}/identity-service/api/auth/refresh-token`, { token: refreshTokenLocal });
    const { token, refreshToken , expiresIn } = response.data;

    // Calculate the expiration date
    const expirationDate = new Date(new Date().getTime() + expiresIn * 1000);

    // Set the new token and refresh token cookies
    Cookies.set('token', token, { expires: expirationDate });
    Cookies.set('refreshToken', refreshToken);

    return token;
  } catch (error) {
    console.error('Failed to refresh access token', error);
    Cookies.remove('refreshToken');
  }
}

export const api = Axios.create({
  baseURL: BACKEND_ENDPOINT,
});

api.interceptors.request.use(authRequestInterceptor);

api.interceptors.response.use(
  (response) => {
    return response.data;
  },
<<<<<<< Updated upstream
  (error) => {
=======
  async (error) => {
    const originalRequest = error.config;

    if (error.response?.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true;

      try {
        const newToken = await refreshAccessToken();
        originalRequest.headers['Authorization'] = `Bearer ${newToken}`;
        return api(originalRequest);
      } catch (refreshError) {
        console.error('Failed to refresh token', refreshError);
        // Optionally, redirect to login page if refresh token fails
        // window.location.href = '/auth/login';
      }
    }

>>>>>>> Stashed changes
    return Promise.reject(error);
  },
);