import { createContext, useState, useContext } from "react";

const TitleContext = createContext({
  pageTitle: "Default Title",
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  setPageTitle: (title: string) => {},
});

export const TitleProvider = ({ children }: { children: React.ReactNode }) => {
  const [pageTitle, setPageTitle] = useState("Default Title");

  return (
    <TitleContext.Provider value={{ pageTitle, setPageTitle }}>
      {children}
    </TitleContext.Provider>
  );
};

export const useTitle = () => useContext(TitleContext);
