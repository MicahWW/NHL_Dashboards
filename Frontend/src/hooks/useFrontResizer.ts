import { useEffect } from "react";
import { adjustFontSize } from "@/utils/fontResizer";

export const useFontResizer = () => {
  useEffect(() => {
    const updateSizes = () => {
      document.querySelectorAll("[data-resizable]").forEach((element) => {
        adjustFontSize(element as HTMLElement);
      });
    };

    window.addEventListener("resize", updateSizes);
    updateSizes(); // Adjust on mount

    return () => window.removeEventListener("resize", updateSizes);
  });
};
