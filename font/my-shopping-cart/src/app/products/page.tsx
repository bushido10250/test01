"use client"

import { useEffect, useState } from 'react';
import {
    Table,
    TableBody,
    TableCaption,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
  } from "@/components/ui/table"

  import {
    Button
  } from "@/components/ui/button"

  import { Input } from "@/components/ui/input"

  type Item = {
    productId: number;
    productName: string;
    description: string;
    price: number;
    createDate : Date;
    stockQuantity : number
  };

  type Cart = {
    productId: number;
    quantity : number
    price : number
  }

export default function Product(){
    const [data, setData] = useState<Item[]>([]);
    const [inputs, setInputs] = useState<number[]>([]);
    const [price, setPrice] = useState<number[]>([]);
    const [cart, setCart] = useState<Cart[]>([]);

    useEffect(() => {
        fetch(process.env.NEXT_PUBLIC_API_URL + '/api/products')
          .then(res => res.json())
          .then(data => {
            setData(data)
            data.forEach((ele:Item) => {
            
            });
          })
          .catch(err => console.error(err));
      }, []);

      function clickAdd(id:number){
        fetch(process.env.NEXT_PUBLIC_API_URL + '/api/products/check', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              ProductId: id,
              Amount: inputs[id],
            }),
          })
            .then(res => {
              if (!res.ok) throw new Error('Network response was not ok');
              return res.json();
            })
            .then(data => {
                if(!data.isOver){
                    alert("Add " + inputs[id] + " items to the cart")
                    const data: Cart = {
                        productId: id,
                        quantity: inputs[id],
                        price: price[id],
                      };
                      setCart([data])
                }
            })
            .catch(err => console.error(err));
          
      }

      const handleChange = (id:number, value:string) => {
        setInputs(prev => ({
          ...prev,
          [id]: parseInt(value, 10) 
        }));
      };
      
    return(
        <div className="flex flex-col justify-center w-7xl">
            <div className="mt-8 ml-8">
                <Button variant="destructive">Cart</Button>
            </div>
            <div className="mt-8">
                <Table>
                    {/* <TableCaption>A list of your recent invoices.</TableCaption> */}
                        <TableHeader>
                            <TableRow>
                                <TableHead className="text-center">number</TableHead>
                                <TableHead className="text-center">product name</TableHead>
                                <TableHead className="text-center">description</TableHead>
                                <TableHead className="text-center">price</TableHead>
                                <TableHead className="text-center">create date</TableHead>
                                <TableHead className="text-center">stock quantity</TableHead>
                                <TableHead className="text-center">buy quantity</TableHead>
                                <TableHead className="text-center"></TableHead>
                            </TableRow>
                        </TableHeader>
                    <TableBody>
                        {data?.map((item:Item, index:number) => (
                            <TableRow key={index}>
                                <TableCell className="text-center">{index+1}</TableCell>
                                <TableCell className="text-center">{item.productName}</TableCell>
                                <TableCell className="text-center">{item.description}</TableCell>
                                <TableCell className="text-center">{item.price}</TableCell>
                                <TableCell className="text-right">{item.createDate.toString()}</TableCell>
                                <TableCell className="text-center">{item.stockQuantity}</TableCell>
                                <TableCell className="text-center"><Input type="text" value={inputs[item.productId] || ""}
                                  onChange={(e) => handleChange(item.productId, e.target.value)}
                                /></TableCell>
                                <TableCell className="text-center"><Button variant="destructive" onClick={() => clickAdd(item.productId)}>Add Cart</Button></TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}