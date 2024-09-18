import './App.css';
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import { Home } from './components/home/Home';
import { Header } from './components/header/Header';
import { ErrorPage } from './components/error-page/ErrorPage';
import { About } from './components/about/About';
import { Mails } from './components/mails/Mails';
import { ProductsInfo } from './components/products/Products';
import { GlobalProvider } from './components/GlobalState';

const mailsArr = ["Letter1", "Letter2", "Letter3"];

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
    errorElement: <ErrorPage />
  },
  {
    path: "/About",
    element: <About />,
    errorElement: <ErrorPage />
  },
  {
    path: "/Mails",
    element: <Mails mailsArr={mailsArr} />,
    errorElement: <ErrorPage />
  },
  {
    path: "/Products",
    element: <ProductsInfo />,
    errorElement: <ErrorPage />
  },
]);

function App() {
  return (
    <GlobalProvider>
      <Header />
      <main>
        <RouterProvider router={router} />
      </main>
    </GlobalProvider>
  );
}

export default App;
