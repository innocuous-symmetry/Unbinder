export interface ButtonProps {
    primary?: boolean;
    label: string;
    'asp-controller'?: string;
    'asp-action'?: string;
    onClick?: () => void;
}

export function createButton({
    primary = false,
    label,
    onClick,
    ...rest
}: ButtonProps): HTMLElement {
    const element = document.createElement("a");

    element.innerText = label;
    element.className = "bg-slate-800 text-white rounded-lg p-2 ml-2 flex flex-col items-center";

    element.setAttribute("asp-controller", rest["asp-controller"] ?? "");
    element.setAttribute("asp-action", rest["asp-action"] ?? "");

    return element;
}
