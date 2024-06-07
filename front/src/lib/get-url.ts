export function getUrl(path?: string) {
    const baseUrl = process.env.NEXT_PUBLIC_BASE_URL || "";
    const normalizedUrl = path && ! path.startsWith("/") ? `/${path}` : path || "";

    return `${baseUrl}${normalizedUrl}`
}