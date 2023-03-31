import { createContext, useState } from "react";

const AddMenusContext = createContext();

export const AddMenusContextProvider = ({ children }) => {
  const [menusIds, setMenusIds] = useState([]);
  const [menuCard, setMenuCard] = useState([]);

  function handleAdd(item) {
    var newItem = [
      {
        id: item.Id,
      },
    ];
    const od = menusIds.concat(newItem);
    setMenusIds(od);

    var newItemCard = [
      {
        id: item.Id,
        menuName: item.MenuTypeName,
        totalPrice: item.TotalPriceForOneDay,
      },
    ];
    const card = menuCard.concat(newItemCard);
    setMenuCard(card);
  }
  console.log(menusIds);
  console.log(menuCard);

  return (
    <AddMenusContext.Provider value={{ menusIds, menuCard, handleAdd }}>
      {children}
    </AddMenusContext.Provider>
  );
};

export default AddMenusContext;
