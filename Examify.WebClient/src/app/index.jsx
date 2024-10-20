import AppProvider from '~/app/provider';
import { AppRouter } from './routes/index';

const App = () => {
  return (
    <AppProvider>
      <AppRouter />
    </AppProvider>
  );
};

export default App;
