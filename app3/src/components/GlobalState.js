import React, { createContext, useState } from 'react';

// Создаем контекст
export const GlobalContext = createContext();

export const GlobalProvider = ({ children }) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  // Функция для смены состояния входа
  const toggleLogin = () => {
    setIsLoggedIn(!isLoggedIn);
  };

  return (
    <GlobalContext.Provider value={{ isLoggedIn, toggleLogin }}>
      {children}
    </GlobalContext.Provider>
  );
};
