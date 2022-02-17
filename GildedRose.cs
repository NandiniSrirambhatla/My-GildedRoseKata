using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        int min_Quality = 0;
        int max_Quality = 50;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                // Lowering SellIn value at the end of the day
                DegradeSellInValue(i);

                // Lowering quality value at the end of the day
                DegradeQualityValue(i);

                // Lowering quality value based on SellIn value

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name == "Aged Brie" && Items[i].Quality < max_Quality)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                    else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                    else if (Items[i].Name != "Aged Brie" && Items[i].Name != "Sulfuras, Hand of Ragnaros" && Items[i].Quality > min_Quality)
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
            }
        }

        public void DegradeSellInValue(int index)
        {
            // Lowering SellIn value at the end of the day

            if (Items[index].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[index].SellIn = Items[index].SellIn - 1;
            }
        }

        public void DegradeQualityValue(int index)
        {
            if (Items[index].Name != "Aged Brie" && Items[index].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[index].Quality > min_Quality)
            {
                // Decreasing the Quality of Conjured Mana Cake twice as fast as normal items
                if (Items[index].Name == "Conjured Mana Cake")
                {
                    Items[index].Quality = Items[index].Quality - 2;
                }
                else if (Items[index].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[index].Quality = Items[index].Quality - 1;
                }
            }
            else if (Items[index].Quality < max_Quality)
            {
                Items[index].Quality = Items[index].Quality + 1;

                if (Items[index].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[index].SellIn < 11 && Items[index].Quality < max_Quality)
                    {
                        Items[index].Quality = Items[index].Quality + 1;
                    }
                    if (Items[index].SellIn < 6 && Items[index].Quality < max_Quality)
                    {
                        Items[index].Quality = Items[index].Quality + 1;
                    }
                }
            }
        }
    }
}
