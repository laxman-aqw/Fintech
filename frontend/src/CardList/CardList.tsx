import React from "react";
import Card from "../Components/Card/Card";

interface Props {}

const CardList = (props: Props) => {
  return (
    <div>
      <Card companyName="Apple" ticker="MSTF" price={100} />
      <Card companyName="Apple" ticker="MSTF" price={100} />
      <Card companyName="Apple" ticker="MSTF" price={100} />
    </div>
  );
};

export default CardList;
