import { useEffect } from 'react';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
  PointElement,
  ArcElement,
} from 'chart.js';
import { Bar, Line, Pie } from 'react-chartjs-2';
import useMenuStore from '~/stores/menu-store';

ChartJS.register(CategoryScale, LinearScale, BarElement, LineElement, Title, Tooltip, Legend, PointElement, ArcElement);

const ReportPage = () => {
  const { setSiderVisible } = useMenuStore();

  useEffect(() => {
    setSiderVisible(true);
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const barData = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
    datasets: [
      {
        label: 'Sales',
        data: [65, 59, 80, 81, 56, 55, 40],
        backgroundColor: 'rgba(75, 192, 192, 0.2)',
        borderColor: 'rgba(75, 192, 192, 1)',
        borderWidth: 1,
      },
      {
        label: 'Expenses',
        data: [40, 49, 60, 71, 36, 45, 30],
        backgroundColor: 'rgba(255, 99, 132, 0.2)',
        borderColor: 'rgba(255, 99, 132, 1)',
        borderWidth: 1,
      },
    ],
  };

  const lineData = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
    datasets: [
      {
        label: 'Revenue',
        data: [75, 69, 90, 95, 76, 85, 60],
        fill: false,
        backgroundColor: 'rgba(54, 162, 235, 0.5)',
        borderColor: 'rgba(54, 162, 235, 1)',
      },
    ],
  };

  const pieData = {
    labels: ['Product A', 'Product B', 'Product C'],
    datasets: [
      {
        label: 'Sales Distribution',
        data: [300, 500, 200],
        backgroundColor: ['rgba(255, 206, 86, 0.7)', 'rgba(54, 162, 235, 0.7)', 'rgba(255, 99, 132, 0.7)'],
        borderWidth: 1,
      },
    ],
  };

  const options = {
    responsive: true,
    plugins: {
      legend: {
        position: 'top',
      },
      title: {
        display: true,
        text: 'Company Performance Overview',
      },
    },
  };

  return (
    <div className="bg-white p-6 rounded-lg shadow-md space-y-8">
      <div>
        <h2 className="text-xl font-semibold mb-4">Bar Chart - Sales & Expenses</h2>
        <Bar data={barData} options={options} />
      </div>
      <div>
        <h2 className="text-xl font-semibold mb-4">Line Chart - Revenue Trend</h2>
        <Line data={lineData} options={options} />
      </div>
      <div>
        <h2 className="text-xl font-semibold mb-4">Pie Chart - Sales Distribution</h2>
        <Pie data={pieData} options={options} />
      </div>
    </div>
  );
};

export default ReportPage;
