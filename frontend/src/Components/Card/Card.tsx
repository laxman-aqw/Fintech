import React from "react";

interface Props {
  companyName?: string;
  ticker?: string;
  price?: number;
  //   description?: string;
}

const Card = ({ companyName, ticker, price }: Props) => {
  return (
    <div className="max-w-sm m-3 bg-white rounded-lg shadow-md overflow-hidden hover:shadow-xl transition-shadow duration-300">
      <img
        src="https://i.pinimg.com/736x/60/6b/c0/606bc0717982547e555a514b479365a0.jpg"
        alt={companyName}
        className="w-full h-48 object-cover"
        loading="lazy"
      />
      <div className="p-4">
        <div className="flex items-center justify-between mb-2">
          <h2 className="text-xl font-semibold text-gray-800">{companyName}</h2>
          <h2 className="text-xl font-semibold text-gray-800">{ticker}</h2>
          <p className="text-lg font-bold text-green-600">${price}</p>
        </div>
        <p className="text-gray-600 text-sm leading-relaxed">
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Eaque, ea
          dignissimos? Cum nihil a quisquam, alias corporis culpa, voluptate
          atque, quaerat libero nisi ab debitis iste dolor tenetur dolorum. Nam!
        </p>
      </div>
    </div>
  );
};

export default Card;
