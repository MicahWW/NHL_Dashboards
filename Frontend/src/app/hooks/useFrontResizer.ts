import { useEffect } from "react";
import { adjustFontSize } from "@/utils/fontResizer";

export const useFontResizer = (selector: string) => {
  useEffect(() => {
    const updateSizes = () => {
      document.querySelectorAll(selector).forEach((element) => {
        adjustFontSize(element as HTMLElement);
      });
    };

    window.addEventListener("resize", updateSizes);
    updateSizes(); // Adjust on mount

    return () => window.removeEventListener("resize", updateSizes);
  });
};
